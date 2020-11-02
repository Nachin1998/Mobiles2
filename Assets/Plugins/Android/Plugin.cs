﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plugin : MonoBehaviour
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

    public void SendLog(string log)
    {
        PluginInstance.Call("SendLog", log);
    }

    public string GetAllLogs()
    {
        return PluginInstance.Call<string>("GetAllLogs");
    }

    public void ButtonTest()
    {
        if(Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Android device not detected");
            return;
        }

        //PluginInstance.Call("SendLog", Time.time.ToString());
        SendLog(Time.time.ToString());

        //Debug.Log(GetAllLogs());
    }
}
