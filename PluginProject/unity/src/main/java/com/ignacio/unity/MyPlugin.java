package com.ignacio.unity;

import android.util.Log;

public class MyPlugin {
    private static final MyPlugin ourInstance = new MyPlugin();
    private static final String LOGTAG = "Ignacio";

    public static final MyPlugin getInstance(){return ourInstance;}

    private long startTime;

    private MyPlugin(){
        Log.i(LOGTAG, "Created MyPlugin");
        startTime = System.currentTimeMillis();
    }

    public double getElapsedTime(){
        return (System.currentTimeMillis()-startTime)/1000.0f;
    }
}
