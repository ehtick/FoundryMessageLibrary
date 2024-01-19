using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FoundryRulesAndUnits.Extensions;

namespace IoBTMessage.Models;

public class VersionInfo : DT_Base
    {
        public string title;
        public string version;
        public string revision;
        public string change;
        public string status; // PUBLISHED, FOR_REVIEW, IN_DRAFT
        public string author;
        public string knowledgecenter;
        public string versionInfo;  //read from the spread sheet  {{revID}}/n{{change}}/n{{asOf}}/n
        public string approvedBy;
        public string filename;
        public string path;

        public string processsPlanGuid;
        public string projectGuid;
        public string worldGuid;
        public int stepCount;
        public int documentCount;
        public int commentCount;
        public string downloadUrl;
        public string description;


        public string lastVersion;
        public string futureVersion;

        public VersionInfo()
        {

        }

        public VersionInfo ShallowCopy()
        {
            var result = (VersionInfo)this.MemberwiseClone();
            return result;
        }

        public VersionInfo GenerateNewVersion()
        {
            var version = IncrementVersion(this.version);

            var result = ShallowCopy();
            result.version = version;
            result.lastVersion = filename;

            result.filename = ComputeNewFilename(filename, version);
            futureVersion = result.filename;
            return result;
        }

        private static string ComputeNewFilename(string oldFilename, string version)
        {
            var name = Path.GetFileNameWithoutExtension(oldFilename);
            var list = name.Split('_');
            list[^1] = version;
            var result = $"{string.Join('_', list)}.json";
            return result;
        }
        public static string IncrementVersion(string ver)
        {
            string answer = "0001";
            if (int.TryParse(ver, out int result))
            {
                result++;
                answer = result.ToString().PadLeft(4, '0');
            }
            return answer;
        }

        public static string ComputeSubfolder(string name)
        {
            var subfolder = name.RemoveExtension();
            subfolder = subfolder.RemoveVersion();
            return subfolder;
        }

        public static string TimeStamp()
        {
            var stamp = DateTime.UtcNow.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            return stamp;
        }



        public static VersionInfo GenerateNext(VersionInfo previous, string name, string title)
        {
            var version = IncrementVersion(previous != null ? previous.version : "0000");
            var filename = name.CleanToFilename();
            var info = new VersionInfo
            {
                title = title,
                name = name,
                version = version,
                status = "DEVELOP",
                filename = $"{filename}_{version}.json",
                timeStamp = TimeStamp()
            };
            return info;
        }

        public static List<VersionInfo> FilterByLatestVersion(List<VersionInfo> source)
        {
            var dict = source
                .OrderByDescending(obj => obj.filename)
                .GroupBy(obj => obj.name ?? obj.title)
                .ToDictionary(g => g.Key, g => g.ToList());

            var list = new List<VersionInfo>();
            foreach (KeyValuePair<string, List<VersionInfo>> entry in dict)
            {
                list.Add(entry.Value.First());
            }
            return list;
        }

    }

