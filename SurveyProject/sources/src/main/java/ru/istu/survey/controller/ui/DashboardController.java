package ru.istu.survey.controller.ui;

import ru.istu.survey.entity.Survey;
import ru.istu.survey.entity.User;
import ru.istu.survey.service.StatisticService;
import ru.istu.survey.service.SurveyService;

import java.security.Principal;
import java.util.List;
import java.util.Map;

/**
 * Created by htim on 21.04.2016.
 */
public class DashboardController {

    private StatisticService statisticService;
    private SurveyService surveyService;


    public String getStatisticBySurvey(String surveyId) {
        return null;
    }

    public List<Survey> getSurveysByUser(User user) {
        return null;
    }

    public Map<String, String> getSettingsByUser(User user) {
        return null;
    }

    public void addSettings(User user, Map<String, String> settings) {

    }

    public Map<String, String> getAdministratorMenu(User user) {
        return null;
    }



}
