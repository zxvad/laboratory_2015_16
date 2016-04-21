package com.example.griz.attendance;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;

public class ListActivity extends AppCompatActivity {
    ListView lv;
    Button SendData;
    Sender sender;
    Getter getData;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_list);
        SendData = (Button) findViewById(R.id.SendDataButton);
        lv= (ListView) findViewById(R.id.listView);
        SendData.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ListModel lm = new ListModel();
                sender.sendData(lm);
            }
        });

    }

}
