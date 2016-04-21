package com.akhmerova.elvira.greenhouse.domain;

import com.akhmerova.elvira.greenhouse.models.Device;
import com.akhmerova.elvira.greenhouse.models.Sensor;
import com.akhmerova.elvira.greenhouse.models.Setting;

import java.util.List;

/**
 * Created by Elvira on 20.04.2016.
 */
public class DataBaseConnectorImpl implements DatBaseConnector {
    @Override
    public List<Device> getDeviceData(long timeBegin, long timeEnd) {
        return null;
    }

    @Override
    public List<Sensor> getSensorData(long timeBegin, long timeEnd) {
        return null;
    }

    @Override
    public void sendSettings(List<Setting> settings) {

    }
}
