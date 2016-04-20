package ru.istu.survey.service;

import ru.istu.survey.dto.ResponseOfSurveyDTO;

public interface ResponseService {

    ResponseOfSurveyDTO create(ResponseOfSurveyDTO responseDTO);

    ResponseOfSurveyDTO findById(String id);
}
