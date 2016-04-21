package ru.istu.survey.mapper;

import ru.istu.survey.SurveyApplication;
import ru.istu.survey.dto.SurveyDTO;
import ru.istu.survey.entity.Survey;
import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.util.ArrayList;
import java.util.List;

@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = SurveyApplication.class)
public class SurveyMapperTest {

    @Autowired
    private SurveyMapper mapper;

    @Test
    public void testMapToEntity() {
        SurveyDTO dto = getSurveyDTO();
        Survey survey = mapper.map(dto, Survey.class);
        Assert.assertEquals(dto.isAnonymous(), survey.isAnonymous());
//        Assert.assertEquals(dto.getAuthor(), survey.getAuthor());
        Assert.assertEquals(dto.getDescription(), survey.getDescription());
        Assert.assertEquals(dto.isPublic(), survey.isPublic());
//        Assert.assertEquals(dto.getQuestion(), survey.get);
        Assert.assertEquals(dto.getState(), survey.getState());
        Assert.assertEquals(dto.getTitle(), survey.getTitle());
    }

    @Test
    public void testMapToDTO() {
        Survey survey = getSurvey();
        SurveyDTO dto = mapper.map(survey, SurveyDTO.class);
        Assert.assertEquals(dto.isAnonymous(), survey.isAnonymous());
//        Assert.assertEquals(dto.getAuthor(), survey.getAuthor());
        Assert.assertEquals(dto.getDescription(), survey.getDescription());
        Assert.assertEquals(dto.isPublic(), survey.isPublic());
//        Assert.assertEquals(dto.getQuestion(), survey.get);
        Assert.assertEquals(dto.getState(), survey.getState());
        Assert.assertEquals(dto.getTitle(), survey.getTitle());
    }

    @Test
    public void testMapToListEntities() {
        final int CAP = 4;
        List<SurveyDTO> dtos = new ArrayList<>(CAP);
        for (int i = 0; i < CAP; i++) dtos.add(getSurveyDTO());

        List<Survey> surveys = mapper.mapAsList(dtos, Survey.class);
        Assert.assertEquals(surveys.size(), CAP);

        SurveyDTO dto = dtos.get(0);
        Survey survey = surveys.get(0);
        Assert.assertEquals(dto.isAnonymous(), survey.isAnonymous());
//        Assert.assertEquals(dto.getAuthor(), survey.getAuthor());
        Assert.assertEquals(dto.getDescription(), survey.getDescription());
        Assert.assertEquals(dto.isPublic(), survey.isPublic());
//        Assert.assertEquals(dto.getQuestion(), survey.get);
        Assert.assertEquals(dto.getState(), survey.getState());
        Assert.assertEquals(dto.getTitle(), survey.getTitle());
    }

    @Test
    public void testMapToListDTO() {
        final int CAP = 4;
        List<Survey> surveys = new ArrayList<>(CAP);
        for (int i = 0; i < CAP; i++) surveys.add(getSurvey());
        List<SurveyDTO> dtos = mapper.mapAsList(surveys, SurveyDTO.class);
        Assert.assertEquals(dtos.size(), CAP);

        Survey survey = surveys.get(0);
        SurveyDTO dto = dtos.get(0);
        Assert.assertEquals(dto.isAnonymous(), survey.isAnonymous());
//        Assert.assertEquals(dto.getAuthor(), survey.getAuthor());
        Assert.assertEquals(dto.getDescription(), survey.getDescription());
        Assert.assertEquals(dto.isPublic(), survey.isPublic());
//        Assert.assertEquals(dto.getQuestion(), survey.get);
        Assert.assertEquals(dto.getState(), survey.getState());
        Assert.assertEquals(dto.getTitle(), survey.getTitle());

    }

    private Survey getSurvey() {
        Survey survey = new Survey();
        survey.setAnonymous(true);
//        dto.setAuthor();
        survey.setDescription("testify");
        survey.setPublic(true);
//        dto.setQuestion();
        survey.setState("state.OK");
        survey.setTitle("testTitle");
        return survey;
    }

    private SurveyDTO getSurveyDTO() {
        SurveyDTO dto = new SurveyDTO();
        dto.setAnonymous(true);
//        dto.setAuthor();
        dto.setDescription("testify");
        dto.setPublic(true);
//        dto.setQuestion();
        dto.setState("state.OK");
        dto.setTitle("testTitle");
        return dto;
    }

}