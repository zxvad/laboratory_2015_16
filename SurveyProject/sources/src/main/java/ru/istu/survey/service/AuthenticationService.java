package ru.istu.survey.service;

import ru.istu.survey.entity.User;

/**
 * Created by htim on 21.04.2016.
 */
public interface AuthenticationService {

    User authenticate(String login, String password);
    boolean isAdmin(User user);


}
