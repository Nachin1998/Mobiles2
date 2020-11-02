package com.ignacio.unity;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.util.Log;

import java.util.ArrayList;

public class MyPlugin {

    private static final String PLUGIN_TAG = "MyPlugin";
    private static final String GAME_TAG = "TP2";
    private static final String separator = "\n";

    private ArrayList<String> logs = new ArrayList<String>();

    private static MyPlugin Instance = null;

    public static Activity mainActivity;
    public interface AlertViewCallback
    {
        public void OnButtonTapped(int id);
    }

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

    public void ShowAlertView(String[] strings, final AlertViewCallback callback)
    {
        if(strings.length<3)
        {
            Log.i(PLUGIN_TAG, "Error - Expected at least 3 string, got " + strings.length);
            return;
        }
        DialogInterface.OnClickListener myClickListener = new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int id) {
                dialogInterface.dismiss();
                Log.i(PLUGIN_TAG, "Tapped: " + id);
                callback.OnButtonTapped(id);
            }
        };

        AlertDialog alertDialog = new AlertDialog.Builder(mainActivity)
                .setTitle(strings[0])
                .setMessage(strings[1])
                .setCancelable(false)
                .create();
        alertDialog.setButton(alertDialog.BUTTON_NEUTRAL, strings[2], myClickListener);
        if(strings.length>3)
        {
            alertDialog.setButton(alertDialog.BUTTON_NEGATIVE, strings[3], myClickListener);
        }
        if(strings.length>4)
        {
            alertDialog.setButton(alertDialog.BUTTON_POSITIVE, strings[4], myClickListener);
        }
        alertDialog.show();
    }
}