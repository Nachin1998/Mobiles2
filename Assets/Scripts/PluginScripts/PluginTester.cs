using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PluginTester : MonoBehaviour
{    
    SuperPlugin sp = null;
    public TextMeshProUGUI text;
    private void Start()
    {
        sp = SuperPlugin.GetInstance();
    }

    public void ButtonTest()
    {
        text.text = sp.GetAllLogs();
        sp.SendLog(Time.time.ToString());
    }
}
