package com.depostelein.backend.service;

import com.depostelein.backend.model.User;
import com.depostelein.backend.repository.UserRepository;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.UnsupportedEncodingException;
import java.util.List;
import java.util.Random;

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;

    public List<User> findAllUsers() {
        List <User> user = userRepository.findAll();
        return user;
    }

    public User addUser(User user) {

        String helper = "ROLE_" + user.getRole();
        User newUser = new User(user.getPassword(), user.getName(), user.getLogin(), user.getEmail(), helper, user.getHelperUserRole());
        return userRepository.saveAndFlush(newUser);
    }

    public User findUser(int id) {
        return userRepository.findOne(id);
    }

    public User findUser(String username, String password){
        List <User> users = userRepository.findAll();

        User loggedinUser = null;
      for (User user : users){
          if (user.getLogin().equals(username) && user.getPassword().equals(password)){
              loggedinUser = user;
          }
      }

      return loggedinUser;
    }

    public User changeUser(int id, User user) {
       // User existingUser = findUser(id);
        //BeanUtils.copyProperties(user, existingUser);

        String helper = "ROLE_" + user.getRole();

        User existingUser = new User(user.getPassword(), user.getName(), user.getLogin(), user.getEmail(), helper, user.getUserRole());
        existingUser.setId(id);
        return userRepository.saveAndFlush(existingUser);
    }

    public User deleteUser(int id) {
        User existingUser = findUser(id);
        userRepository.delete(existingUser);
        return existingUser;
    }

}
