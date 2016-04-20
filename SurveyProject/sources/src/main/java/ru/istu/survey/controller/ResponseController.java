package ru.istu.survey.controller;

import ru.istu.survey.dto.ResponseOfSurveyDTO;
import ru.istu.survey.service.ResponseService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/response")
public class ResponseController {

    @Autowired
    private ResponseService responseService;

    @RequestMapping(method = RequestMethod.POST, produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseOfSurveyDTO submit(@RequestBody ResponseOfSurveyDTO responseDTO) {
        return responseService.create(responseDTO);
    }

    @RequestMapping(value = "/{id}", method = RequestMethod.GET, produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseOfSurveyDTO getById(@PathVariable String id) {
        return responseService.findById(id);
    }

}
