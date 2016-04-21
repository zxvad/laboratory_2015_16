package ru.istu.survey.repository;

import ru.istu.survey.entity.Survey;
import org.bson.types.ObjectId;
import org.springframework.data.mongodb.repository.MongoRepository;

import java.util.List;

public interface SurveyRepository extends MongoRepository<Survey, ObjectId> {
    List<Survey> findByTitle(String title);

    Iterable<Survey> deleteByTitle(String title);
}
