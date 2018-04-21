package com.depostelein.backend.controller;

import com.depostelein.backend.model.User;
import com.depostelein.backend.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;
import org.json.JSONObject;


@RestController
@RequestMapping("api/user/")
public class UserController {

    @Autowired
    private UserService userService;

    @RequestMapping(value = "users", method = RequestMethod.GET)
    @Secured({"ROLE_USER", "ROLE_ADMIN"})
    public ResponseEntity getAllUsers() {

        return ResponseEntity.ok(userService.findAllUsers());
    }

    @RequestMapping(value = "users", method = RequestMethod.POST)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity postUser(@RequestBody User user) {

            return ResponseEntity.ok(userService.addUser(user));
    }

    @RequestMapping(value = "login", method = RequestMethod.POST)
    @Secured({"ROLE_ADMIN", "ROLE_USER"})
    public ResponseEntity validateLogin(@RequestBody String credentials) {
        User user = null;
        try {
            JSONObject object = new JSONObject(credentials);

            user = userService.findUser(object.getString("login"), object.getString("password"));
        } catch (Exception ex){

        }
        return ResponseEntity.ok(user);

    }

    @RequestMapping(value = "users/{id}", method = RequestMethod.GET)
    @Secured({"ROLE_LECTURER", "ROLE_ADMIN"})
    public ResponseEntity getUser(@PathVariable int id) {
        return ResponseEntity.ok(userService.findUser(id));
    }

    @RequestMapping(value = "users/{id}", method = RequestMethod.PUT)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity updateUser(@PathVariable int id, @RequestBody User user) {
        return ResponseEntity.ok(userService.changeUser(id, user));
    }

    @RequestMapping(value = "users/{id}", method = RequestMethod.DELETE)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity deleteUser(@PathVariable int id) {
        return ResponseEntity.ok(userService.deleteUser(id));
    }
}
