package com.akhmerova.elvira.greenhouse.view.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.widget.Toast;

import com.akhmerova.elvira.greenhouse.App;
import com.akhmerova.elvira.greenhouse.Navigator;
import com.akhmerova.elvira.greenhouse.R;

import butterknife.ButterKnife;
import butterknife.OnClick;

/**
 * Created by Elvira on 20.04.2016.
 */
public class WelcomeActivity extends AppCompatActivity {
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_welcome);
        ButterKnife.bind(this);
    }

    @OnClick(R.id.btn_welcome)
    void onClick() {
        if (App.isNetworkAvailable()) {
            Navigator.startOnline(this);
            finish();
        } else {
            Toast.makeText(this, R.string.error_connection, Toast.LENGTH_SHORT).show();
            Navigator.startOffline(this);
        }
    }
}
