package com.ignacio.unity;

import android.util.Log;

import java.util.ArrayList;

public class MyPlugin {

    private static final String PLUGIN_TAG = "MyPlugin";
    private static final String GAME_TAG = "TP2";
    private static final String separator = "\n";

    private ArrayList<String> logs = new ArrayList<String>();

    private static MyPlugin Instance = null;

    public static MyPlugin GetInstance()
    {
        if(Instance == null)
        {
            Log.d(PLUGIN_TAG, "Logger created");
            Instance = new MyPlugin();
        }
        return Instance;
    }

    public void SendLog(String log)
    {
        Log.d(GAME_TAG, log);
        logs.add(log);
    }

    public String GetAllLogs()
    {
        Log.d(PLUGIN_TAG, "GetAllLogs() function called");
        String aux = "";
        for (int i = 0; i < logs.size(); i++)
        {
            aux += logs.get(i) + separator;
        }
        return aux;
    }
}
