public abstract class SuperPlugin
{
    public static SuperPlugin GetInstance(){
#if UNITY_EDITOR || UNITY_STANDALONE
        return new PCPlugin();

#elif UNITY_ANDROID || UNITY_IOS
        return new AndroidPlugin();
        
#endif
    }
    public abstract void SendLog(string log);
    public abstract string GetAllLogs();
    public abstract void ShowLogsWindow();
}
