using System.Text.Json.Serialization;
namespace DTARServer.Models;

[System.Serializable]
public class DT_Project : DT_Base
{

    public string title;
    public string system;
    public List<DT_ProcessPlan> processPlans;

#if !UNITY
    public DT_Project() : base()
    {
    }

    public DT_ProcessPlan AddProcessPlan(DT_ProcessPlan plan)
    {
        if (processPlans == null)
        {
            processPlans = new List<DT_ProcessPlan>();
        }
        processPlans.Add(plan);
        return plan;
    }

    public DT_Project CreateRandomPlans(int i)
    {
        var r = new Random();
        foreach (var j in Enumerable.Range(0, i))
        {
            int rInt = r.Next(10000, 99000); //for ints
            var plan = new DT_ProcessPlan()
            {
                name = $"process plan {rInt}",
                title = $"Process Plan {rInt}"
            };
            this.AddProcessPlan(plan);
            plan.CreateRandomStep(7);
        };
        return this;
    }

    public DT_Project ShallowCopy()
    {
        var result = (DT_Project)this.MemberwiseClone();
        result.processPlans = new List<DT_ProcessPlan>();
        return result;
    }
#endif
}


