package com.depostelein.backend.service;

import com.depostelein.backend.model.User;
import com.depostelein.backend.repository.UserRepository;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;

    public List<User> findAllUsers() {
        return userRepository.findAll();
    }

    public User addUser(User user) {
        return userRepository.saveAndFlush(user);
    }

    public User findUser(int id) {
        return userRepository.findOne(id);
    }

    public User changeUser(int id, User user) {
        User existingUser = findUser(id);
        BeanUtils.copyProperties(user, existingUser);
        return userRepository.saveAndFlush(existingUser);
    }

    public User deleteUser(int id) {
        User existingUser = findUser(id);
        userRepository.delete(existingUser);
        return existingUser;
    }

}
