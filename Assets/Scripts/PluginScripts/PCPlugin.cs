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
    public override void ShowAlertDialog(string[] strings, System.Action<int> handler = null)
    {
        if (strings.Length < 3)
        {
            Debug.LogError("Not an android device");
            return;
        }
    }

    public override void ClearLogs()
    {
        Debug.Log("Cant clear logs, not on Android device");
    }
}