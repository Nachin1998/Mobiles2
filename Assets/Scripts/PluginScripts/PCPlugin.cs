using UnityEngine;

public class PCPlugin : SuperPlugin
{    
    public override void SendLog(string log)
    {
        Debug.Log("Send log to SuperPlugin: " + log);
    }

    public override string GetAllLogs()
    {
        return "Not in Android";        
    }
}