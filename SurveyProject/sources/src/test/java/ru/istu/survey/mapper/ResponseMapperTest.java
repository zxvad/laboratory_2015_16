package ru.istu.survey.mapper;

import ru.istu.survey.SurveyApplication;
import ru.istu.survey.dto.ResponseOfSurveyDTO;
import ru.istu.survey.entity.ResponseOfSurvey;
import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = SurveyApplication.class)
public class ResponseMapperTest {

    @Autowired
    private ResponseMapper mapper;

    private ResponseOfSurveyDTO responseOfSurveyDTO = new ResponseOfSurveyDTO();
    private ResponseOfSurvey responseOfSurvey = new ResponseOfSurvey();

    {
        responseOfSurveyDTO.setSurveyId("1");
        responseOfSurveyDTO.setRespondentId("2");
        responseOfSurvey.setSurveyId("3");
        responseOfSurvey.setRespondentId("4");
    }

    @Test
    public void testMapToEntity() {
        ResponseOfSurvey entity = mapper.map(responseOfSurveyDTO, ResponseOfSurvey.class);
        Assert.assertEquals(entity.getSurveyId(), responseOfSurveyDTO.getSurveyId());
        Assert.assertEquals(entity.getRespondentId(), responseOfSurveyDTO.getRespondentId());
    }

    @Test
    public void testMapToDTO() {
        ResponseOfSurveyDTO dto = mapper.map(responseOfSurvey, ResponseOfSurveyDTO.class);
        Assert.assertEquals(dto.getSurveyId(), responseOfSurvey.getSurveyId());
        Assert.assertEquals(dto.getRespondentId(), responseOfSurvey.getRespondentId());
    }

}