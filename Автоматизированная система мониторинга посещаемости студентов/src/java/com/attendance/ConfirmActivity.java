package com.example.griz.attendance;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

public class ConfirmActivity extends AppCompatActivity {

    Sender sendData;
    Getter getData;
    Button ConfirmButton;
    ListView lv;
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_confirm);
        ConfirmButton= (Button) findViewById(R.id.submitButton);
        lv= (ListView) findViewById(R.id.listView2);
    }
}
