package com.example.griz.attendance;

/**
 * Created by Михаил(Griz) on 21.04.2016.
 */
public class Entry implements IEntry {
    @Override
    public boolean checkLogin(String Login) {
        return false;
    }

    @Override
    public boolean checkPass(String Password) {
        return false;
    }
}
