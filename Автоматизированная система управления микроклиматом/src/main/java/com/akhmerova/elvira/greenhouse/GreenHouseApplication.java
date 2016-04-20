package com.akhmerova.elvira.greenhouse;

import com.akhmerova.elvira.greenhouse.domain.DatBaseConnector;
import com.akhmerova.elvira.greenhouse.domain.DataHandler;
import com.akhmerova.elvira.greenhouse.domain.SettingsManager;

/**
 * Created by Elvira on 20.04.2016.
 */
public interface GreenHouseApplication {
    DatBaseConnector getDataDatBaseConnector();
    DataHandler getDataHandler();
    SettingsManager getSettingsManager();
}
