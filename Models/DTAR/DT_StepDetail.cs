namespace DTARServer.Models;

[System.Serializable]
public class DT_StepDetail : DT_Hero
{
	public int itemNumber;

	public DT_QualityAssurance check;

#if !UNITY
	public DT_StepDetail() : base()
    {
    }

	public override List<DT_Document> CollectDocuments(List<DT_Document> list)
	{
		base.CollectDocuments(list);

		return list;
	}

	public DT_StepDetail ShallowCopy()
	{
		var result = (DT_StepDetail)this.MemberwiseClone();
		result.assetReferences = null;
		result.ClearKeys();
		result.DeReference();
		return result;
	}

#endif
}


[System.Serializable]
public class DT_Note : DT_StepDetail
{

}

[System.Serializable]
public class DT_Caution : DT_StepDetail
{
}

[System.Serializable]
public class DT_Warning : DT_StepDetail
{
}

[System.Serializable]
public class DT_StepAction : DT_StepDetail
{
}

[System.Serializable]
public class DT_CAD : DT_StepDetail
{
}

[System.Serializable]
public class DT_Media : DT_StepDetail
{
}
