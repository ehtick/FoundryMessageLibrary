namespace DTARServer.Models;

[System.Serializable]
public class DT_Note : DT_ProcessStep
{
    public string text;
    public string icon;
}

[System.Serializable]
public class DT_Caution : DT_ProcessStep
{
    public string text;
    public string icon;
}

[System.Serializable]
public class DT_Warning : DT_ProcessStep
{
    public string text;
    public string icon;
}

[System.Serializable]
public class DT_Step : DT_ProcessStep
{
    public string text;
    public string icon;
}
