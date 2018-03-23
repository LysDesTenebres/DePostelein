package com.depostelein.backend.model;

import com.depostelein.backend.model.Enums.UserRole;
import org.springframework.stereotype.Component;

import javax.persistence.*;
import java.io.UnsupportedEncodingException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.Random;

@Component
@Entity
public class User {

    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    private int id;
    private String password;
    private String salt;
    private String name;
    private String login;
    private String email;
    private boolean enabled = true;
    private String role;
    @Enumerated(EnumType.STRING)
    private UserRole userRole;
    @Transient
    private String help;

    public User() {
    }

    public User(String password, String name, String login, String email, String role, String userRole) {
        this.password = password;
        this.name = name;
        this.login = login;
        this.email = email;
        this.role = role;
        this.salt = GenerateSalt();
        try {
            this.password = HashPassword(password, this.salt);
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }
        if (userRole.equals(UserRole.ADMIN.name())){
            this.userRole = UserRole.ADMIN;
        } else if (userRole.equals(UserRole.COLD.name())) {
            this.userRole = UserRole.COLD;
        }

        this.help = userRole;

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

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getLogin() {
        return login;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    public String getUserRole() {
        return userRole.toString();
    }

    public void setHelp (String help){
        this.help = help;
    }
    public String getHelperUserRole(){
        return help;
    }

    public void setUserRole(String userRole) {
        if (userRole.equals(UserRole.ADMIN.name())){
            this.userRole = UserRole.ADMIN;
        } else if (userRole.equals(UserRole.COLD.name())) {
            this.userRole = UserRole.COLD;
        }
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }

    public void isEnabled(boolean enabled) { this.enabled = enabled; }

    public boolean getEnabled(){ return enabled;}
}
