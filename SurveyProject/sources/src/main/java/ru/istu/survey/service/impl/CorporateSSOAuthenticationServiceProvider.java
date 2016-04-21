package ru.istu.survey.service.impl;

import ru.istu.survey.entity.User;
import ru.istu.survey.service.AuthenticationService;

/**
 * Created by htim on 21.04.2016.
 */
public class CorporateSSOAuthenticationServiceProvider implements AuthenticationService {


    @Override
    public User authenticate(String login, String password) {
        return null;
    }

    @Override
    public boolean isAdmin(User user) {
        return false;
    }
}
