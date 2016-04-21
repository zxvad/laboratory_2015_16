package com.example.griz.attendance;

import android.os.Bundle;
import android.view.View;


public interface IEntry {
    public boolean checkLogin(String Login);
    public  boolean checkPass(String Password);
}
