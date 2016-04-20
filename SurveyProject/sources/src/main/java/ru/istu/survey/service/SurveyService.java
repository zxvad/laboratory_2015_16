package ru.istu.survey.service;

import ru.istu.survey.dto.SurveyDTO;

import java.util.List;

public interface SurveyService {

    SurveyDTO create(SurveyDTO survey);

    SurveyDTO update(SurveyDTO surveyDTO);

    List<SurveyDTO> findAll();

    List<SurveyDTO> findByTitle(String title);

    SurveyDTO findById(String id);

    List<SurveyDTO> deleteByTitle(String title);

    void deleteAll();
}
