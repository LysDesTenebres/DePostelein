package com.depostelein.backend.model;

import org.springframework.stereotype.Component;

import javax.persistence.Entity;
import javax.persistence.Id;
import java.io.UnsupportedEncodingException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.Random;

@Component
@Entity
public class User {

    @Id
    private int id;
    private String password;
    private String salt;
    private String name;
    private String login;
    private boolean enabled = true;
    private String role;

    public User() {
    }

    public User(int id, String password, String name, String login, String function) {
        this.id = id;
        this.password = password;
        this.name = name;
        this.login = login;
        this.role = function;
        this.salt = GenerateSalt();
        try {
            this.password = HashPassword(password, this.salt);
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }
    }

    public String GenerateSalt() {
        char[] chars = "abcdefghijklmnopqrstuvwxyz".toCharArray();
        StringBuilder sb = new StringBuilder();
        Random random = new Random();
        for (int i = 0; i < 32; i = i + 1) {
            sb.append(chars[random.nextInt(chars.length)]);
        }
        return sb.toString();
    }

    public String HashPassword(String passwordToHash, String salt) throws UnsupportedEncodingException {
        String generatedPassword = null;
        try {
            MessageDigest md = MessageDigest.getInstance("SHA-512");
            md.update(salt.getBytes("UTF-8"));
            byte[] bytes = md.digest(passwordToHash.getBytes("UTF-8"));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.length; i++) {
                sb.append(Integer.toString((bytes[i] & 0xff) + 0x100, 16).substring(1));
            }
            generatedPassword = sb.toString();
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        }
        return generatedPassword;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getLogin() {
        return login;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    public String getFunction() {
        return role;
    }

    public void setFunction(String function) {
        this.role = function;
    }

    public void isEnabled(boolean enabled) { this.enabled = enabled; }

    public boolean getEnabled(){ return enabled;}
}
