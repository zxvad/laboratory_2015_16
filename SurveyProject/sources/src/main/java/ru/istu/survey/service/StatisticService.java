package ru.istu.survey.service;

import org.springframework.stereotype.Service;

/**
 * Created by htim on 21.04.2016.
 */

@Service
public interface StatisticService {

    void performFrequencyStatistic(String id);
    void performContingencyTableStatistic(String firstId, String secondId);

}
