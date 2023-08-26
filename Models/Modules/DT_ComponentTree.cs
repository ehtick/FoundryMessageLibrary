using FoundryRulesAndUnits.Extensions;

namespace IoBTMessage.Models;

public class DT_ComponentTree<V> : DT_Title where V : DT_Component
{
    public V item;
    private readonly List<V> _sourceChildren;
    public int level;
    public int index;
    public string path;
    public string indent;
    public double key;

    private DT_ComponentTree<V> _parent;
    public List<DT_ComponentTree<V>> children;

    public DT_ComponentTree(V node, List<V> sourceChildren, int index, int level)
    {
        this.item = node;
        this._sourceChildren = sourceChildren;

        this.guid = node.guid;
        this.level = level;
        this.index = index;
        this.name = item.part.ComputeTitle();
        this.key = level + index / 100;

        var spaces = "_________________________________________________________________________"[..(2 * (level - 1))];
        this.indent = $"{spaces}{level}.{index}";
        this.title = $"{spaces}{this.name}";
    }

    public string ComputePath()
    {
        if (!string.IsNullOrWhiteSpace(path)) return path;

        path = index.ToString().PadLeft(2, '0');
        if (_parent != null)
        {
            path = $"{_parent.ComputePath()}.{path}";
        }
        return path;
    }
    public DT_Component AsBOM()
    {
        var result = item.ShallowCopy();
        result.title = title;
        // Per meeting on 5/11/2023 - use item description
        // result.description = $"{ComputePath()}: {item.part?.ComputeTitle()}";
        return result;
    }

    public bool MatchesNode(DT_ComponentTree<V> node)
    {
        var myPart = this.item.part;
        var otherPart = node.item.part;

        return myPart.partNumber.Matches(otherPart.partNumber);
    }

    //  https://github.com/force-net/DeepCloner
    public List<V> SourceChildren(bool clone)
    {
        if (clone)
        {
            var result = _sourceChildren.Select(item => item.ShallowCopy()).ToList();
            return result as List<V>;
        }
        return _sourceChildren;
    }

    public List<Import_BOM> WriteToImportBomList(List<Import_BOM> list)
    {
        var part = new Import_BOM()
        {
            structureLevel = level.ToString(),
            GUID = item.guid,
            name = item.name,
            description = item.description,
            nha = item.parentAssembly,
            number = item.part?.partNumber,
            address = item.part?.partNumber,
            refDes = item.part?.referenceDesignation,
            itemNumber = ComputePath(),
            quanty = "1",
        };

        list.Add(part);

        children?.ForEach(child => child.WriteToImportBomList(list));

        return list;
    }

    public DT_ComponentTree<V> AddChildNode(DT_ComponentTree<V> child)
    {
        this.children ??= new List<DT_ComponentTree<V>>();
        this.children.Add(child);
        child._parent = this;
        return child;
    }

    public List<DT_ComponentTree<V>> CollectLeafNodes(List<DT_ComponentTree<V>> list)
    {
        if (children == null || children.Count == 0)
            list.Add(this);
        else
            children?.ForEach(child => child.CollectLeafNodes(list));

        return list;
    }

    public DT_ComponentTree<V> SimplifyForExport()
    {
        path = ComputePath();
        children?.ForEach(child => child.SimplifyForExport());

        return this;
    }

    public List<DT_ComponentTree<V>> CollectAllNodes(List<DT_ComponentTree<V>> list)
    {
        list.Add(this);
        children?.ForEach(child => child.CollectAllNodes(list));

        return list;
    }

    public List<V> CollectAllComponents(List<V> list)
    {
        list.Add(this.item);
        children?.ForEach(child => child.CollectAllComponents(list));

        return list;
    }

    public DT_ComponentTree<V> ApplyNodeAsTemplate(DT_ComponentTree<V> root, int depth)
    {
        //DO NOT ADD CHILD FROM TEMPLATE IF IT ALREADY EXIST !!

        if (root == null) return null;
        children ??= new List<DT_ComponentTree<V>>();

        var found = children.Find(child => child.MatchesNode(root));
        if (found == null)
        {
            var newestChild = root.item.ShallowCopy() as V;
            newestChild.guid = Guid.NewGuid().ToString();
            newestChild.parentAssembly = this.item.part.partNumber;

            var node = new DT_ComponentTree<V>(newestChild, root.SourceChildren(true), children.Count + 1, level + 1);
            AddChildNode(node);

            //root.children?.ForEach(child => node.ApplyNodeAsTemplate(child, depth + 1));
        }

        return root;
    }
}
