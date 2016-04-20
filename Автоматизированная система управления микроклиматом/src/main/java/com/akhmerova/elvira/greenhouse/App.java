package com.akhmerova.elvira.greenhouse;

import android.app.Application;
import android.content.Context;
import android.net.ConnectivityManager;

import com.akhmerova.elvira.greenhouse.domain.DatBaseConnector;
import com.akhmerova.elvira.greenhouse.domain.DataBaseConnectorImpl;
import com.akhmerova.elvira.greenhouse.domain.DataHandler;
import com.akhmerova.elvira.greenhouse.domain.DataHandlerImpl;
import com.akhmerova.elvira.greenhouse.domain.SettingsManager;

/**
 * Created by Elvira on 20.04.2016.
 */
public class App extends Application implements GreenHouseApplication {
    private static DataHandler dataHandler;
    private static DatBaseConnector datBaseConnector;
    private static SettingsManager settingsManager;
    private static GreenHouseApplication greenApplication;
    private static Application application;

    public static GreenHouseApplication getGreenInstance() {
        return greenApplication;
    }

    public static Application getInstance() {
        return application;
    }

    @Override
    public void onCreate() {
        super.onCreate();
        dataHandler = new DataHandlerImpl();
        datBaseConnector = new DataBaseConnectorImpl();
        greenApplication = this;
        application = this;
    }

    @Override
    public DatBaseConnector getDataDatBaseConnector() {
        return datBaseConnector;
    }

    @Override
    public DataHandler getDataHandler() {
        return dataHandler;
    }

    @Override
    public SettingsManager getSettingsManager() {
        return null;
    }

    public static boolean isNetworkAvailable() {
        return ((ConnectivityManager) application.getSystemService(Context.CONNECTIVITY_SERVICE)).getActiveNetworkInfo() != null;
    }
}
