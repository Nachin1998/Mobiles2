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
}
