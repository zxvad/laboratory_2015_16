package com.akhmerova.elvira.greenhouse.domain;

import com.akhmerova.elvira.greenhouse.models.Device;
import com.akhmerova.elvira.greenhouse.models.Sensor;

import java.util.List;

/**
 * Created by Elvira on 20.04.2016.
 */
public interface DataHandler {
    void generateClimateState(List<Sensor> sensors, List<Device> devices);
    void generateCurrentState(Sensor sensor, Device device);
}
