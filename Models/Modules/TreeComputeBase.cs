// this is a tool to load/unload knowledge modules that define projects


using FoundryRulesAndUnits.Extensions;

namespace IoBTMessage.Models;

public class TreeNode
{
    public bool IsVisited { get; set; }
    public string name { get; set; }
    public DT_Component item { get; set; }
    public List<string> childNames { get; set; } = new List<string>();
    public List<TreeNode> childNodes { get; set; } = new List<TreeNode>();
}

public interface ITreeComputeBase
{

    List<DT_Component> ComponentsWithParentAssembly(string nha);
    List<DT_Component> ComponentsWithParent(DT_Component parent, bool deep = true);

    void ValidateComponents(IDataRepository repo);
    void ValidateAssemblies(IDataRepository repo);
    DT_ComponentTree<DT_Component> BuildTreeFrom(DT_Component root);
    DT_ComponentTree<DT_Component> BuildListUsing(DT_Component root, List<DT_Component> list);
    DT_ComponentTree<DT_Component> FindTreeNode(DT_Component root);
    DT_ComponentTree<DT_Component> EnrichComponentTree(DT_ComponentTree<DT_Component> root);
}

public class TreeComputeBase : ITreeComputeBase
{
    private LookupObjectStore<DT_ComponentTree<DT_Component>> _treeDB { set; get; } = new();

    private readonly IComponents _db;

    public TreeComputeBase(IComponents components)
    {
        _db = components;
    }


    public DT_Component FindComponent(string guid)
    {
        return _db.FindComponent(guid);
    }

    public List<DT_Component> Components()
    {
        return _db.AllComponents();
    }

    public List<DT_Component> RootComponents()
    {
        return _db.RootComponents();
    }

    public List<DT_Component> OrphanComponents()
    {
        return _db.OrphanComponents();
    }

    public void ValidateComponents(IDataRepository repo)
    {
        var allComponents = Components();
        if (allComponents.Count == 0) return;

        FindCircularities(repo);

        //SRS to do look for circular references
        var list = RootComponents();
        if (list.Count == 0)
            repo.AddWarning($"BOM is missing a component with a NHA = END");

        foreach (var orphan in OrphanComponents())
            repo.AddWarning($"BOM item {orphan.part.ComputeTitle()} is an Orphan");
    }

    public void ValidateAssemblies(IDataRepository repo)
    {
        var allComponents = Components();
        if (allComponents.Count == 0) return;

    }

    private List<TreeNode> CollectCycles(TreeNode root, List<TreeNode> result, Dictionary<string, TreeNode> tree)
    {
        if (root.IsVisited)
        {
            result.Add(root);
        }
        else
        {
            root.IsVisited = true;
            root.childNodes.ForEach(child =>
            {
                CollectCycles(child, result, tree);
            });
        }
        return result;
    }
    private void FindCircularities(IDataRepository repo)
    {
        Dictionary<string, TreeNode> tree = new();

        foreach (var item in Components())
        {
            var child = item.part.partNumber;
            var parent = item.parentAssembly;


            if (tree.ContainsKey(parent))
            {
                var node = tree[parent];
                node.childNames.Add(child);
            }
            else
            {
                var node = new TreeNode() { name = child, item = item };
                tree.Add(parent, node);
            }
        }

        //now it is time to look for cycles 
        var nodes = tree.Values.OrderBy(x => x.name);
        foreach (var node in nodes)
        {
            nodes.ForEach(item => item.IsVisited = false); // mak as unvisited
            var cycle = CollectCycles(node, new List<TreeNode>(), tree);
            var part = node.item.part;
            if (cycle.Count > 0)
            {
                node.item.parentAssembly = "ORPHAN";
                repo.AddWarning($"{part.ComputeTitle()} is a part of a cycle");
            }
            else
            {
                //$"No Cycles for {part.ComputeTitle()}  -- {node.item.name}".WriteSuccess();
            }
        }

    }

    public List<DT_Component> ComponentsWithParentAssembly(string parentAssembly)
    {
        var result = Components().Where(item => item.parentAssembly == parentAssembly).ToList();
        return result;
    }


    public List<DT_Component> ComponentsWithParent(DT_Component parent, bool deep = true)
    {
        var result = Components().Where(item => item.parentGuid == parent.guid).ToList();
        return result;
    }


    public List<DT_Component> ComponentsWithParent(DT_Component parent)
    {
        var result = Components().Where(item => item.parentGuid == parent.guid).ToList();
        return result;
    }

    public DT_ComponentTree<DT_Component> FindTreeNode(DT_Component root)
    {
        if (root == null) return null;
        var node = _treeDB.FindOrCreateGUID(root.guid, false);
        return node;
    }

    public DT_ComponentTree<DT_Component> BuildTreeFrom(DT_Component root)
    {

        _treeDB = new();
        var result = BuildTreeNode(root, 1, 1);
        return result;
    }

    public DT_ComponentTree<DT_Component> BuildTreeFromList(List<DT_Component> list)
    {

        _treeDB = new();
        var root = new DT_Component()
        {
            guid = "ROOT",
            part = new DT_Part() { partNumber = "END" },
            parentAssembly = "ROOT",
            systemName = "ROOT",
        };

        int i = 1;
        var result = BuildTreeNode(root, i, i);
        foreach (var item in list)
        {
            var node = BuildTreeNode(item, i++, result.level + 1);
            result.AddChildNode(node);
        }
        return result;
    }


    public DT_ComponentTree<DT_Component> BuildTreeNode(DT_Component item, int index, int level)
    {
        if (item == null) return null;

        var node = FindTreeNode(item);
        if (node == null)
        {
            var children = ComponentsWithParentAssembly(item.part.partNumber);
            node = new DT_ComponentTree<DT_Component>(item, children, index, level);
            _treeDB.FindAddOrMergeGUID(node);

            var i = 1;
            foreach (var child in node.SourceChildren(false))
            {
                var childNode = BuildTreeNode(child, i++, level + 1);
                node.AddChildNode(childNode);
            }
        }
        return node;
    }



    public DT_ComponentTree<DT_Component> BuildListUsing(DT_Component root, List<DT_Component> list)
    {
        var result = new DT_ComponentTree<DT_Component>(root, null, 1, 1);

        var i = 1;
        foreach (var child in list)
        {
            var node = new DT_ComponentTree<DT_Component>(child, null, i++, 2);
            result.AddChildNode(node);
        }
        return result;
    }

    public DT_ComponentTree<DT_Component> BuildListNode(DT_Component item, int index, int level)
    {
        if (item == null) return null;

        var node = FindTreeNode(item);
        if (node == null)
        {
            var children = ComponentsWithParentAssembly(item.part.partNumber);
            node = new DT_ComponentTree<DT_Component>(item, children, index, level);
            _treeDB.FindAddOrMergeGUID(node);

            var i = 1;
            foreach (var child in node.SourceChildren(false))
            {
                var childNode = BuildTreeNode(child, i++, level + 1);
                node.AddChildNode(childNode);
            }
        }
        return node;
    }

    public DT_ComponentTree<DT_Component> EnrichComponentTree(DT_ComponentTree<DT_Component> root)
    {
        if (root == null) return null;
        var list = root.CollectLeafNodes(new List<DT_ComponentTree<DT_Component>>());

        var roots = RootComponents();
        var assemblies = roots.Select(item => BuildTreeFrom(item)).ToList();

        foreach (var item in list)
        {
            var found = assemblies.Where(child => child.MatchesNode(item)).FirstOrDefault();
            //add the children
            found?.children?.ForEach(child => item.ApplyNodeAsTemplate(child, 0));

        }
        return root;
    }

}

