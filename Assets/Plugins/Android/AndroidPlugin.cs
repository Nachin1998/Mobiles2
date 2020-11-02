using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlugin : SuperPlugin
{
    const string pluginName = "com.ignacio.unity.MyPlugin";

    static AndroidJavaClass pluginClass = null;
    public static AndroidJavaClass PluginClass
    {
        get
        {
            if (pluginClass == null)
            {
                pluginClass = new AndroidJavaClass(pluginName);
            }
            return pluginClass;
        }
    }


    static AndroidJavaObject pluginInstance = null;
    public static AndroidJavaObject PluginInstance
    {
        get
        {
            if (pluginInstance == null)
            {
                pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("GetInstance");
            }
            return pluginInstance;
        }
    }

    public override void SendLog(string log)
    {
        PluginInstance.Call("SendLog", log);
    }

    public override string GetAllLogs()
    {
        return PluginInstance.Call<string>("GetAllLogs");
    }

    public override void ShowLogsWindow()
    {
        throw new System.NotImplementedException();
    }
}
