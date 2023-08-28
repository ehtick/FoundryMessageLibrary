

using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Models;

    public class WorkbookDefinition : DT_Base
    {
        public bool IsUnsaved;
        public DT_Hero source;
        public VersionInfo info;
        public List<VersionInfo> modules;
        public List<DT_AssetFile> documents;


        public WorkbookDefinition UpdateModuleInfo(VersionInfo info)
        {
            modules ??= new List<VersionInfo>();
            modules.Add(info);
            modules = modules.OrderByDescending(obj => obj.version).ToList();
            return this;
        }

        public List<VersionInfo> LatestModules()
        {
            modules ??= new List<VersionInfo>();
            var latest = VersionInfo.FilterByLatestVersion(modules);
            return latest;
        }
    }

