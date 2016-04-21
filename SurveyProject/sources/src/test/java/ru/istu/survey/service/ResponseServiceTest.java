package ru.istu.survey.service;

import ru.istu.survey.SurveyApplication;
import ru.istu.survey.dto.ResponseOfSurveyDTO;
import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = SurveyApplication.class)
public class ResponseServiceTest {

    @Autowired
    private ResponseService service;

    @Test
    public void testCreateAndFindById() {
        ResponseOfSurveyDTO dto = new ResponseOfSurveyDTO();
        dto.setSurveyId("1");
        dto.setRespondentId("2");
        ResponseOfSurveyDTO saved = service.create(dto);
        ResponseOfSurveyDTO found = service.findById(saved.getId());
        Assert.assertEquals(dto.getSurveyId(), found.getSurveyId());
        Assert.assertEquals(dto.getRespondentId(), found.getRespondentId());
    }
}