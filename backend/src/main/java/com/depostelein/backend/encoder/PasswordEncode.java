package com.depostelein.backend.encoder;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.security.authentication.encoding.Md5PasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.ResourceBundle;

public class PasswordEncode implements PasswordEncoder {

    @Override
    public String encode(CharSequence rawPassword) {

        return encodePassword(rawPassword.toString());

    }

    @Override
    public boolean matches(CharSequence rawPassword, String encodedPassword) {
        return encodePassword(rawPassword.toString())
                .equals(encodedPassword);
    }

    public String encodePassword(String password){
        String salt = ResourceBundle.getBundle("application").getString("salt");
        String generatedPassword = null;
        try {
            MessageDigest md = MessageDigest.getInstance("SHA-256");
            md.update(salt.getBytes("UTF-8"));
            byte[] bytes = md.digest(password.toString().getBytes("UTF-8"));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.length; i++) {
                sb.append(Integer.toString((bytes[i] & 0xff) + 0x100, 16).substring(1));
            }
            generatedPassword = sb.toString();
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        } catch (Exception ex){

        }
        return generatedPassword;
    }

}

