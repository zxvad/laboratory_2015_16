package ru.istu.survey.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import ru.istu.survey.service.StatisticService;

/**
 * Created by htim on 21.04.2016.
 */
@Controller
public class StatisticController {

    @Autowired
    private StatisticService statisticService;

}
