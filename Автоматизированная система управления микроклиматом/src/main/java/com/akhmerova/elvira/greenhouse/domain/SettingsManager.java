package com.akhmerova.elvira.greenhouse.domain;

import com.akhmerova.elvira.greenhouse.models.Setting;

import java.util.List;

/**
 * Created by Elvira on 20.04.2016.
 */
public interface SettingsManager {
    int inputCode();
    List<Setting> inputSettings();
    boolean isRightCode(int code);
}
