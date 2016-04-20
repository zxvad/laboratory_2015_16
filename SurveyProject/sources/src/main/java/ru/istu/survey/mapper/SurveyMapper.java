package ru.istu.survey.mapper;

import ru.istu.survey.dto.SurveyDTO;
import ru.istu.survey.entity.Survey;
import ma.glasnost.orika.MapperFactory;
import ma.glasnost.orika.impl.ConfigurableMapper;
import org.springframework.stereotype.Component;

@Component
public class SurveyMapper extends ConfigurableMapper{
    /**
     * Implement this method to provide your own configurations to
     * the Orika MapperFactory used by this mapper.
     *
     * @param factory the MapperFactory instance which may be used to
     *                register various configurations, mappings, etc.
     */
    @Override
    protected void configure(MapperFactory factory) {
        factory.classMap(Survey.class, SurveyDTO.class)
                .byDefault()
                .register();
    }
}
