using UnityEngine;

public class AndroidPlugin : SuperPlugin
{
    const string pluginName = "com.ignacio.unity.MyPlugin";

    class AlertViewCallback : AndroidJavaProxy
    {
        private System.Action<int> alertHandler;

        public AlertViewCallback(System.Action<int> alertHandlerIn) : base(pluginName + "$AlertViewCallback")
        {
            alertHandler = alertHandlerIn;
        }
        public void OnButtonTapped(int index)
        {
            Debug.Log("Button Tapped: " + index);
            if(alertHandler != null)
            {
                alertHandler(index);
            }
        }
    }
    
    static AndroidJavaClass pluginClass = null;
    
    public static AndroidJavaClass PluginClass
    {
        get
        {
            if (pluginClass == null)
            {
                pluginClass = new AndroidJavaClass(pluginName);
                AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
                pluginClass.SetStatic<AndroidJavaObject>("mainActivity", activity);
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

    public override void ShowAlertDialog(string[] strings, System.Action<int> handler = null)
    {
        if(strings.Length < 3)
        {
            Debug.LogError("AlertView requires at least 3 strings");
            return;
        }

        if(Application.platform == RuntimePlatform.Android)
        {
            PluginInstance.Call("ShowAlertView", new object[] { strings, new AlertViewCallback(handler) });
        }
        else
        {
            Debug.LogWarning("AlertView not supported on this platform");
        }
    }

    public override void ClearLogs()
    {
        PluginInstance.Call("ClearLogs");
    }
}
