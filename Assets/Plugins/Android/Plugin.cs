using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plugin : MonoBehaviour
{
    const string pluginName = "com.ignacio.unity.MyPlugin";
    static AndroidJavaClass pluginClass;
    static AndroidJavaObject pluginInstance;

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

    public static AndroidJavaObject PluginInstance
    {
        get
        {
            if (pluginInstance == null)
            {
                pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
            return pluginInstance;
        }
    }

    float elapsedTime = 0;
    void Start() 
    { 
        Debug.Log("Elapsed time" + getElapsedTime());
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 5f)
        {
            Debug.Log("Tick: " + getElapsedTime()); 
            elapsedTime = 0;
        }
    }

    double getElapsedTime()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            return pluginInstance.Call<double>("getElapsedTime");
        }
        
        Debug.LogWarning("Not an android");
        return 0;
    }
}
