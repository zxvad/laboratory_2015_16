package com.akhmerova.elvira.greenhouse;

import android.content.Context;
import android.content.Intent;

import com.akhmerova.elvira.greenhouse.view.activities.MainActivity;
import com.akhmerova.elvira.greenhouse.view.activities.ReportActivity;

/**
 * Created by Elvira on 20.04.2016.
 */
public class Navigator {
    public static void startOnline(Context context) {
        context.startActivity(new Intent(context, MainActivity.class));
    }

    public static void startOffline(Context context) {
        context.startActivity(new Intent(context, ReportActivity.class));
    }
}
