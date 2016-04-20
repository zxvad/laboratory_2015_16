package ru.istu.survey.service.impl;

import ru.istu.survey.dto.SurveyDTO;
import ru.istu.survey.entity.Survey;
import ru.istu.survey.mapper.SurveyMapper;
import ru.istu.survey.repository.SurveyRepository;
import ru.istu.survey.service.SurveyService;
import org.bson.types.ObjectId;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class SurveyServiceImpl implements SurveyService {

    @Autowired
    private SurveyRepository surveyRepository;

    @Autowired
    private SurveyMapper mapper;

    @Override
    public SurveyDTO create(SurveyDTO surveyDTO) {
        Survey survey = mapper.map(surveyDTO, Survey.class);
        Survey saved = surveyRepository.insert(survey);
        SurveyDTO result = mapper.map(saved, SurveyDTO.class);
        return result;
    }

    @Override
    public SurveyDTO update(SurveyDTO surveyDTO) {
        Survey survey = mapper.map(surveyDTO, Survey.class);
        Survey saved = surveyRepository.save(survey);
        SurveyDTO result = mapper.map(saved, SurveyDTO.class);
        return result;
    }


    @Override
    public List<SurveyDTO> findAll() {
        return mapper.mapAsList(surveyRepository.findAll(), SurveyDTO.class);
    }

    @Override
    public List<SurveyDTO> deleteByTitle(String title) {
        Iterable<Survey> deletedSurveys = surveyRepository.deleteByTitle(title);
        return mapper.mapAsList(deletedSurveys, SurveyDTO.class);
    }

    @Override
    public void deleteAll() {
        surveyRepository.deleteAll();
    }

    @Override
    public List<SurveyDTO> findByTitle(String title) {
        return mapper.mapAsList(surveyRepository.findByTitle(title), SurveyDTO.class);
    }

    @Override
    public SurveyDTO findById(String id) {
        ObjectId objectId = new ObjectId(id);
        return mapper.map(surveyRepository.findOne(objectId), SurveyDTO.class);
    }

}
