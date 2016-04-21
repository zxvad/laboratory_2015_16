package com.example.griz.attendance;

import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.text.method.ScrollingMovementMethod;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import static android.widget.Toast.*;


public class LoginActivity extends AppCompatActivity implements View.OnClickListener{

    Button AuthButton;
    EditText Login;
    EditText Password;
    List<ListModel> list;
	Sender sendData;
    Entry enter;
    Getter getData;
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        Login= (EditText) findViewById(R.id.Login);
        Password = (EditText) findViewById(R.id.Password);
        AuthButton= (Button)findViewById(R.id.AuthButton);
        Sender sender= new Sender();

    }
    @Override
    public void onClick(View v) {
        Entry enter= new Entry();
        switch (v.getId())
        {
            case R.id.AuthButton:
                if(enter.checkLogin(Login.getText().toString()) && enter.checkPass(Password.getText().toString()))
                {
                    intent = new Intent(this, ListActivity.class);
                    startActivity(intent);
                }
                break;
        }
    }
}

