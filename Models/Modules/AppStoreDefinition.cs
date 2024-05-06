// this is a tool to load/unload knowledge modules that define projects
using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Models;



public class AppStoreDefinition : DT_Hero
{
    public bool loadAfterLogin;
    public List<VersionInfo> versionList;

    public AppStoreDefinition()
    {
        loadAfterLogin = false;
    }

    public bool CanLoadOnLogin()
    {
        return loadAfterLogin;
    }

    public bool SetLoadOnLogin(bool value)
    {
        if ( loadAfterLogin != value)
            loadAfterLogin = value;
            
        return loadAfterLogin;
    }
    public AppStoreDefinition AfterCreation()
    {
        versionList ??= new List<VersionInfo>();
        versionList = versionList.OrderByDescending(obj => obj.version).ToList();
        return this;
    }


    public void UpdateWorkbookIndex(WorkbookDefinition def)
    {
        versionList ??= new List<VersionInfo>();

        var found = versionList.Where(ver => ver.name == def.info.name).FirstOrDefault();
        if (found != null) versionList.Remove(found);

        versionList.Add(def.info);
        versionList = versionList.OrderByDescending(obj => obj.version).ToList();
    }

    public AppStoreDefinition RefreshFromHero(DT_Hero hero, string prefix)
    {
        this.name = hero.name;
		var title = hero.title ?? hero.name ?? "Unknown";

		this.title = $"{prefix} {title.Replace("_", " ")}".Trim();
        this.heroImage = hero.heroImage;

        return this;
    }



    public string LatestVersionNumber(string init)
    {
        if (versionList == null) return init;
        var result = LatestVersion().version;

        result = VersionInfo.IncrementVersion(result);
        return result;
    }

    public VersionInfo LatestVersion()
    {
        if (versionList == null) return null;

        var result = versionList.OrderByDescending(obj => obj.version).ToList();
        return result[0];
    }

}
