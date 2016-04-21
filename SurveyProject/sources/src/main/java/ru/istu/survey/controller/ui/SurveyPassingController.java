package ru.istu.survey.controller.ui;

import ru.istu.survey.entity.AnswerOption;

import java.util.List;

/**
 * Created by htim on 21.04.2016.
 */
public interface SurveyPassingController {

    String getQuestion(String id);
    void passAnswers(List<AnswerOption> options);

}
