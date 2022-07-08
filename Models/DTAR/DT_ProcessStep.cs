namespace DTARServer.Models;

[System.Serializable]
public class DT_ProcessStep : DT_Base
{
    public string title;
    public string number;
    public List<DT_AssetReference> assetReferences;

#if !UNITY
    public DT_ProcessStep() : base()
    {
    }

    public T AddReference<T>(T doc) where T : DT_AssetReference
    {
        if (assetReferences == null)
        {
            assetReferences = new List<DT_AssetReference>();
        }
        assetReferences.Add(doc);
        return doc;
    }

    public DT_ProcessStep AddToPlan(DT_ProcessPlan plan)
    {
        plan.AddStep(this);
        return this;
    }

    // public DT_ProcessStep Document(string name, string url = "", string page = "")
    // {
    //     var extractedFilename = url.Split('/').Last<string>();
    //     var dwg = new DT_Document()
    //     {
    //         name = name,
    //         url = url,
    //         page = page,
    //         filename = extractedFilename
    //     };
    //     AddDocument(dwg);
    //     return this;
    // }
    // public DT_ProcessStep Drawing(string title = "", string description = "", string url = "", string page = "")
    // {
    //     var extractedFilename = url.Split('/').Last<string>();
    //     var dwg = new DT_Document()
    //     {
    //         title = $"Dwg. {title}",
    //         name = title,
    //         description = description,
    //         url = url,
    //         page = page,
    //         filename = extractedFilename
    //     };
    //     AddDocument(dwg);
    //     return this;
    // }

    // public DT_ProcessStep Video(string name, string url, int startTime, int stopTime)
    // {
    //     var extractedFilename = url.Split('/').Last<string>();
    //     var video = new DT_Video()
    //     {
    //         name = name,
    //         url = url,
    //         filename = extractedFilename,
    //         start_time = startTime,
    //         end_time = stopTime
    //     };
    //     AddDocument(video);
    //     return this;
    // }

#endif
}


