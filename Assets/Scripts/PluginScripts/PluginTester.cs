using TMPro;
using UnityEngine;

public class PluginTester : MonoBehaviour
{    
    SuperPlugin sp = null;
    private void Start()
    {
        sp = SuperPlugin.GetInstance();
    }

    public void SendLog(string log)
    {
        sp.SendLog(log);
    }

    public void SendGameTimeLog()
    {
        sp.SendLog(GameManager.Instance.gameTimer.ToString());
    }

    public void ShowLogs(TextMeshProUGUI text)
    {
        //sp.SendLog(Time.time.ToString());
        //sp.SendLog(GameManager.Instance.gameTimer.ToString());
        text.text = sp.GetAllLogs();
    }

    public void ClearLogs(TextMeshProUGUI text)
    {
        sp.ShowAlertDialog(new string[] { "Warning", "You are about to clear all logs. Are you sure?", "Confirm", "Cancel" }, (int obj) =>
        {
            Debug.Log("Local handler called: " + obj);
            sp.ClearLogs();
            text.text = "Logs cleared";
        });
    }
}
