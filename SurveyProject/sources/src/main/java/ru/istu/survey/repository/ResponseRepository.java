package ru.istu.survey.repository;

import ru.istu.survey.entity.ResponseOfSurvey;
import org.bson.types.ObjectId;
import org.springframework.data.mongodb.repository.MongoRepository;

public interface ResponseRepository extends MongoRepository<ResponseOfSurvey, ObjectId> {
}
