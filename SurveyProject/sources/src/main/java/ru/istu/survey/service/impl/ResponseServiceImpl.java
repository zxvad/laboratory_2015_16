package ru.istu.survey.service.impl;

import ru.istu.survey.dto.ResponseOfSurveyDTO;
import ru.istu.survey.entity.ResponseOfSurvey;
import ru.istu.survey.mapper.ResponseMapper;
import ru.istu.survey.repository.ResponseRepository;
import ru.istu.survey.service.ResponseService;
import org.bson.types.ObjectId;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ResponseServiceImpl implements ResponseService {

    @Autowired
    private ResponseRepository repository;

    @Autowired
    private ResponseMapper mapper;


    @Override
    public ResponseOfSurveyDTO create(ResponseOfSurveyDTO responseDTO) {
        ResponseOfSurvey response = mapper.map(responseDTO, ResponseOfSurvey.class);
        ResponseOfSurvey saved = repository.insert(response);
        ResponseOfSurveyDTO dto = mapper.map(saved, ResponseOfSurveyDTO.class);
        return dto;
    }

    @Override
    public ResponseOfSurveyDTO findById(String id) {
        ObjectId objectId = new ObjectId(id);
        ResponseOfSurvey found = repository.findOne(objectId);
        ResponseOfSurveyDTO dto = mapper.map(found, ResponseOfSurveyDTO.class);
        return dto;
    }
}
