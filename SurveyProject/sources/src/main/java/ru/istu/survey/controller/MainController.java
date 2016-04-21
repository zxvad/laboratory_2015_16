package ru.istu.survey.controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.security.Principal;
import java.util.HashMap;
import java.util.Map;

@RestController
public class MainController {

    @RequestMapping("/user")
    public Principal user(Principal user) {
        return user;
    }

    @RequestMapping("/content")
    public Map<String, String> home() {
        return new HashMap<String, String>() {{
            put("content", "Hello world");
        }};
    }
}
