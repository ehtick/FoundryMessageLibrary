namespace DTARServer.Models;

[System.Serializable]
public class DT_ProcessPlan : DT_Base
{
    public string title;

    public List<DT_AssetReference> assetReferences;
    public List<DT_ProcessStep> steps;



#if !UNITY
    public DT_ProcessPlan()
    {
    }

    public T AddStep<T>(T step) where T : DT_ProcessStep
    {
        if (steps == null)
        {
            steps = new List<DT_ProcessStep>();
        }
        steps.Add(step);
        return step;
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

    public DT_ProcessPlan CreateRandomStep(int i)
    {
        foreach (var j in Enumerable.Range(1, i + 1))
        {
            var plan = new DT_ProcessStep()
            {
                name = $"Step  {j}",
                number = $"j"
            };
            this.AddStep(plan);
        };
        return this;
    }



    public DT_ProcessPlan ShallowCopy()
    {
        var result = (DT_ProcessPlan)this.MemberwiseClone();
        result.steps = new List<DT_ProcessStep>();
        result.assetReferences = new List<DT_AssetReference>();
        return result;
    }
#endif
}


