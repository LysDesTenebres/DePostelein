package com.depostelein.backend.model;

import com.depostelein.backend.model.Enums.UserRole;
import org.springframework.stereotype.Component;

import javax.persistence.*;
import java.io.UnsupportedEncodingException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.ResourceBundle;

@Component
@Entity
public class User {

    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    private int id;
    private String password;
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

    public User(String password, String name, String login, String email, String role, String kitchenRole) {
        this.password = password;
        this.name = name;
        this.login = login;
        this.email = email;
        this.role = role;
        try {
            this.password = HashPassword(password);
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }
        if (kitchenRole.equals(UserRole.ADMIN.name())){
            this.userRole = UserRole.ADMIN;
        } else if (kitchenRole.equals(UserRole.HAPJES.name())) {
            this.userRole = UserRole.HAPJES;
        } else if (kitchenRole.equals(UserRole.KOUD.name())) {
            this.userRole = UserRole.KOUD;
        } else if (kitchenRole.equals(UserRole.GROENTEN.name())) {
            this.userRole = UserRole.GROENTEN;
        } else if (kitchenRole.equals(UserRole.BEREIDINGEN.name())) {
            this.userRole = UserRole.BEREIDINGEN;
        } else if (kitchenRole.equals(UserRole.AARDAPPELBEREIDINGEN.name())) {
            this.userRole = UserRole.AARDAPPELBEREIDINGEN;
        } else if (kitchenRole.equals(UserRole.SAUZEN.name())) {
            this.userRole = UserRole.SAUZEN;
        } else if (kitchenRole.equals(UserRole.VIS.name())) {
            this.userRole = UserRole.VIS;
        } else if (kitchenRole.equals(UserRole.DESSERT.name())) {
            this.userRole = UserRole.DESSERT;
        } else if (kitchenRole.equals(UserRole.DRANKEN.name())) {
            this.userRole = UserRole.DRANKEN;
        } else if (kitchenRole.equals(UserRole.LOGISTIEK.name())) {
            this.userRole = UserRole.LOGISTIEK;
        }
        this.help = kitchenRole;

    }


    public String HashPassword(String passwordToHash) throws UnsupportedEncodingException {
        String salt = ResourceBundle.getBundle("application").getString("salt");
        String generatedPassword = null;
        try {
            MessageDigest md = MessageDigest.getInstance("SHA-256");
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
        } else if (userRole.equals(UserRole.HAPJES.name())) {
            this.userRole = UserRole.HAPJES;
        } else if (userRole.equals(UserRole.KOUD.name())) {
            this.userRole = UserRole.KOUD;
        } else if (userRole.equals(UserRole.GROENTEN.name())) {
            this.userRole = UserRole.GROENTEN;
        } else if (userRole.equals(UserRole.BEREIDINGEN.name())) {
            this.userRole = UserRole.BEREIDINGEN;
        } else if (userRole.equals(UserRole.AARDAPPELBEREIDINGEN.name())) {
            this.userRole = UserRole.AARDAPPELBEREIDINGEN;
        } else if (userRole.equals(UserRole.SAUZEN.name())) {
            this.userRole = UserRole.SAUZEN;
        } else if (userRole.equals(UserRole.VIS.name())) {
            this.userRole = UserRole.VIS;
        } else if (userRole.equals(UserRole.DESSERT.name())) {
            this.userRole = UserRole.DESSERT;
        } else if (userRole.equals(UserRole.DRANKEN.name())) {
            this.userRole = UserRole.DRANKEN;
        } else if (userRole.equals(UserRole.LOGISTIEK.name())) {
            this.userRole = UserRole.LOGISTIEK;
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
