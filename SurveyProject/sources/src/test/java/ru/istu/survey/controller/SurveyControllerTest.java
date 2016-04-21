package ru.istu.survey.controller;

import ru.istu.survey.SurveyApplication;
import ru.istu.survey.dto.SurveyDTO;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.http.MediaType;
import org.springframework.http.converter.HttpMessageConverter;
import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;
import org.springframework.mock.http.MockHttpInputMessage;
import org.springframework.mock.http.MockHttpOutputMessage;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.test.context.web.WebAppConfiguration;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.MvcResult;
import org.springframework.web.context.WebApplicationContext;

import java.io.IOException;
import java.util.Arrays;

import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;
import static org.springframework.test.web.servlet.setup.MockMvcBuilders.webAppContextSetup;

@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = SurveyApplication.class)
@WebAppConfiguration
public class SurveyControllerTest {

    @Autowired
    private WebApplicationContext webApplicationContext;

    @Autowired
    void setConverters(HttpMessageConverter<?>[] converters) {

        this.mappingJackson2HttpMessageConverter = Arrays.asList(converters).stream().filter(
                hmc -> hmc instanceof MappingJackson2HttpMessageConverter).findAny().get();

        Assert.assertNotNull("the JSON message converter must not be null",
                this.mappingJackson2HttpMessageConverter);
    }

    private MockMvc mockMvc;

    private HttpMessageConverter mappingJackson2HttpMessageConverter;

    @Before
    public void setup() throws Exception {
        this.mockMvc = webAppContextSetup(webApplicationContext).build();
    }

    @Test
    public void testSurveyCreateRest() throws Exception {
        SurveyDTO surveyDTO = new SurveyDTO();
        surveyDTO.setTitle("SurveyCreateRest");
        String surveyDTOJson = convertToJson(surveyDTO);
        mockMvc.perform(post("/survey/")
                .content(surveyDTOJson)
                .contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(status().isOk());
    }

    @Test
    public void testSurveyCreateAndFindRest() throws Exception {
        SurveyDTO surveyDTO = new SurveyDTO();
        surveyDTO.setTitle("SurveyCreateAndFindRest");
        String surveyDTOJson = convertToJson(surveyDTO);
        MvcResult mvcResult = mockMvc.perform(post("/survey/")
                .content(surveyDTOJson)
                .contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(status().isOk()).andReturn();
        SurveyDTO foundSurvey = convertToObject(mvcResult.getResponse().getContentAsByteArray());
        Assert.assertEquals(surveyDTO.getTitle(), foundSurvey.getTitle());
    }

    private String convertToJson(Object o) throws IOException {
        MockHttpOutputMessage mockHttpOutputMessage = new MockHttpOutputMessage();
        this.mappingJackson2HttpMessageConverter.write(
                o, MediaType.APPLICATION_JSON, mockHttpOutputMessage);
        return mockHttpOutputMessage.getBodyAsString();
    }

    private SurveyDTO convertToObject(byte[] content) throws IOException {
        Assert.assertTrue(this.mappingJackson2HttpMessageConverter.canRead(SurveyDTO.class, MediaType.APPLICATION_JSON));

        MockHttpInputMessage mockHttpInputMessage = new MockHttpInputMessage(content);
        SurveyDTO result = (SurveyDTO) this.mappingJackson2HttpMessageConverter.read(
                SurveyDTO.class, mockHttpInputMessage);
        return result;
    }

}
