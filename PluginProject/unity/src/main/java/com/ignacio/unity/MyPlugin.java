package com.ignacio.unity;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.util.Log;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
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
        //SaveData(log);
    }

    public void ClearLogs()
    {
        logs.clear();
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

    public void ShowAlertView(String[] strings, final AlertViewCallback callback) {
        if (strings.length < 3) {
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
                .setNegativeButton(strings[3], new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface arg0, int arg1) {
                    }
                })
                .setCancelable(false)
                .create();
        alertDialog.setButton(alertDialog.BUTTON_POSITIVE, strings[2], myClickListener);
        alertDialog.show();
    }

    public void SaveData(String string){

        File file = new File("../logs.txt");
        try {
            FileWriter fw = new FileWriter(file);
            PrintWriter pw = new PrintWriter(fw);

            pw.println(string);
          pw.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
