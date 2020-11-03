public abstract class SuperPlugin
{       
    public static SuperPlugin GetInstance(){

#if UNITY_EDITOR
        return new PCPlugin();

#elif UNITY_ANDROID
        return new AndroidPlugin();
        
#endif
    }

    public abstract void SendLog(string log);
    public abstract string GetAllLogs();
    public abstract void ShowAlertDialog(string[] strings, System.Action<int> handler = null);
    public abstract void ClearLogs();
}
