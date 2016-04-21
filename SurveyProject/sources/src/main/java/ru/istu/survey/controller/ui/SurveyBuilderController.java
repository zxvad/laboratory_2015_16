package ru.istu.survey.controller.ui;

import ru.istu.survey.entity.AnswerOption;
import ru.istu.survey.entity.Survey;

/**
 * Created by htim on 21.04.2016.
 */
public interface SurveyBuilderController {

    String getAbailableAnswerTypes();
    String getAnswerDescription();
    void addSurvey(Survey survey);

}
