// this is a tool to load/unload knowledge modules that define projects

using System.Collections.Generic;
using FoundryRulesAndUnits.Models;

namespace IoBTMessage.Models;


public class ModuleDefinition : DT_Title
{
    private bool _IsUnsaved;
    public string source;
    public DT_Part part;
    public VersionInfo info;

    public DT_ProcessPlan process;
    public DT_Document mildoc;
    public List<DT_ProcessStep> steps;
    public List<DT_Component> components;
    public List<DT_Component> subs;
    public List<DT_Sensor> sensors;
	public List<DT_Component> netlistNodes;
	public List<DT_Component> netlistLinks;
    public List<DT_AssetFile> assetFiles;
    public List<DT_AssetReference> assetRefs;
    public DT_System system;
    public UDTO_World world;
    public UDTO_Position location;

    public List<PartAsCSV> inventory;


    public ModuleDefinition AfterCreation()
    {
        info.stepCount = steps == null ? 0 : steps.Count;
        info.documentCount =  assetFiles == null ? 0 : assetFiles.Count;

        if (process != null) {
            var list = process.CollectComments(new List<DT_Comment>());
            info.commentCount = list.Count;
        }

        return this;
    }

    public bool IsUnsaved() {
        return _IsUnsaved;
    }
    public bool SetUnsaved(bool value) {
        _IsUnsaved = value;
        return IsUnsaved();
    }
}




