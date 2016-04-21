package ru.istu.survey.service;

import ru.istu.survey.SurveyApplication;
import ru.istu.survey.dto.SurveyDTO;
import org.hamcrest.Matcher;
import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.test.context.web.WebAppConfiguration;

import java.util.List;

import static org.hamcrest.CoreMatchers.is;
import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.hasProperty;
import static org.hamcrest.core.IsCollectionContaining.hasItem;

@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = SurveyApplication.class)
@WebAppConfiguration
public class SurveyServiceTest {

    @Autowired
    private SurveyService surveyService;

    @Test
    public void testSurveySavedSuccessfully() {
        SurveyDTO surveyDTO = new SurveyDTO();
        surveyDTO.setTitle("New survey");
        surveyService.create(surveyDTO);
        List<SurveyDTO> storedSurveys = surveyService.findAll();
        List<SurveyDTO> storedSurveysByTitle = surveyService.findByTitle("New survey");
        assertThat(storedSurveysByTitle, (Matcher) hasItem(hasProperty("title", is("New survey"))));
    }

    @Test
    public void testSurveyCreateAndFind() {
        SurveyDTO surveyDTO = new SurveyDTO();
        surveyDTO.setTitle("SurveyCreateAndFind");
        SurveyDTO createdSurvey = surveyService.create(surveyDTO);
        SurveyDTO foundSurvey = surveyService.findById(createdSurvey.getId());
        Assert.assertEquals(surveyDTO.getTitle(), foundSurvey.getTitle());
    }

}
