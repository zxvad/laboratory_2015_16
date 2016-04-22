package ru.istu.survey.controller;

import ru.istu.survey.SurveyApplication;
import ru.istu.survey.dto.ResponseOfSurveyDTO;
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
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.web.context.WebApplicationContext;

import java.io.IOException;
import java.util.Arrays;

import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = SurveyApplication.class)
@WebAppConfiguration
public class ResponseControllerTest {

    private MockMvc mockMvc;
    private ResponseOfSurveyDTO dto;
    private HttpMessageConverter mappingJackson2HttpMessageConverter;
    @Autowired
    private WebApplicationContext webApplicationContext;

    @Autowired
    void setConverters(HttpMessageConverter<?>[] converters) {
        mappingJackson2HttpMessageConverter = Arrays.asList(converters).stream().filter(
                hmc -> hmc instanceof MappingJackson2HttpMessageConverter).findAny().get();

        Assert.assertNotNull("the JSON message converter must not be null", mappingJackson2HttpMessageConverter);
    }

    @Before
    public void setup() {
        mockMvc = MockMvcBuilders.webAppContextSetup(webApplicationContext).build();
        dto = new ResponseOfSurveyDTO();
        dto.setSurveyId("1");
        dto.setRespondentId("11");
    }

    @Test
    public void testSubmit() throws Exception {
        mockMvc.perform(post("/response/")
                .contentType(MediaType.APPLICATION_JSON_UTF8)
                .content(json(dto)))
                .andExpect(status().isOk());
    }

    @Test
    public void testSubmitAndCompare() throws Exception {
        MvcResult result = mockMvc.perform(post("/response/")
                .contentType(MediaType.APPLICATION_JSON_UTF8)
                .content(json(dto)))
                .andReturn();
        ResponseOfSurveyDTO saved = convertToResponseOfSurveyDTO(result.getResponse().getContentAsByteArray());
        Assert.assertEquals(dto.getSurveyId(), saved.getSurveyId());
        Assert.assertEquals(dto.getRespondentId(), saved.getRespondentId());
    }

    @Test
    public void testFindById() throws Exception {
        MvcResult result = mockMvc.perform(post("/response/")
                .contentType(MediaType.APPLICATION_JSON_UTF8)
                .content(json(dto)))
                .andReturn();
        ResponseOfSurveyDTO saved = convertToResponseOfSurveyDTO(result.getResponse().getContentAsByteArray());

        result = mockMvc.perform(get("/response/" + saved.getId() + "/")
                .contentType(MediaType.APPLICATION_JSON_UTF8))
                .andReturn();
        ResponseOfSurveyDTO found = convertToResponseOfSurveyDTO(result.getResponse().getContentAsByteArray());
        Assert.assertEquals(dto.getSurveyId(), found.getSurveyId());
        Assert.assertEquals(dto.getRespondentId(), found.getRespondentId());
    }

    private String json(Object o) throws IOException {
        MockHttpOutputMessage mockHttpOutputMessage = new MockHttpOutputMessage();
        mappingJackson2HttpMessageConverter.write(o, MediaType.APPLICATION_JSON_UTF8, mockHttpOutputMessage);
        return mockHttpOutputMessage.getBodyAsString();
    }

    private ResponseOfSurveyDTO convertToResponseOfSurveyDTO(byte[] bytes) throws IOException {
        Assert.assertTrue(mappingJackson2HttpMessageConverter
                .canRead(ResponseOfSurveyDTO.class, MediaType.APPLICATION_JSON));
        MockHttpInputMessage mockHttpInputMessage = new MockHttpInputMessage(bytes);
        ResponseOfSurveyDTO result = (ResponseOfSurveyDTO) mappingJackson2HttpMessageConverter.read(
                ResponseOfSurveyDTO.class, mockHttpInputMessage);
        return result;
    }
}