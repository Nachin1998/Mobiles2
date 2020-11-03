using TMPro;
using UnityEngine;

public class PluginTester : MonoBehaviour
{    
    SuperPlugin sp = null;
    private void Start()
    {
        sp = SuperPlugin.GetInstance();
    }

    public void ShowLogs(TextMeshProUGUI text)
    {
        text.text = sp.GetAllLogs();    
        sp.SendLog(Time.time.ToString());
    }

    public void ClearLogs()
    {
        sp.ShowAlertDialog(new string[] { "Warning", "You are about to clear all logs. Are you sure?", "Confirm", "Cancel" }, (int obj) =>
        {
            Debug.Log("Local handler called: " + obj);
            sp.ClearLogs();
        });
    }
}
