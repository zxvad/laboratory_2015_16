package ru.istu.survey.controller;

import ru.istu.survey.dto.SurveyDTO;
import ru.istu.survey.entity.Survey;
import ru.istu.survey.service.SurveyService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/survey")
@CrossOrigin(origins = "http://localhost:8000")
public class SurveyController {

    private static final Logger log = LoggerFactory.getLogger(SurveyController.class);

    @Autowired
    private SurveyService surveyService;

    @RequestMapping(method = RequestMethod.POST, produces = MediaType.APPLICATION_JSON_VALUE)
    public SurveyDTO createSurvey(@RequestBody SurveyDTO surveyDTO) {
        return surveyService.create(surveyDTO);
    }

    @RequestMapping(method = RequestMethod.PUT, produces = MediaType.APPLICATION_JSON_VALUE)
    public SurveyDTO updateSurvey(@RequestBody SurveyDTO surveyDTO) {
        return surveyService.update(surveyDTO);
    }

    /**
     * тестовый ресурс
     * возвращает пустой опрос:
     * {"state":null,"author":null,"title":null,"description":null,"questions":null,"public":false,"anonymous":false}
     */
    @RequestMapping(value = "/test", method = RequestMethod.GET, produces = MediaType.APPLICATION_JSON_VALUE)
    public Survey testSurvey() {
        return new Survey();
    }

    @RequestMapping(method = RequestMethod.GET, produces = MediaType.APPLICATION_JSON_VALUE)
    public List<SurveyDTO> getAll() {
        return surveyService.findAll();
    }

    @RequestMapping(value = "/{id}", method = RequestMethod.GET, produces = MediaType.APPLICATION_JSON_VALUE)
    public SurveyDTO getSurvey(@PathVariable("id") String id) {
        return surveyService.findById(id);
    }

    @RequestMapping(method = RequestMethod.DELETE)
    public HttpStatus deleteAll() {
        surveyService.deleteAll();
        return HttpStatus.OK;
    }

    @ResponseStatus(value = HttpStatus.INTERNAL_SERVER_ERROR)
    @ExceptionHandler(Exception.class)
    public void handleException(Exception e) {
        log.error("Error: ", e);
    }

}
