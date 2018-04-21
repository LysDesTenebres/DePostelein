package com.android.depostelein.deposteleinandroid.Models;

import java.io.Serializable;

public class User implements Serializable {

        private int id;
        private String password;
        private String name;
        private String login;
        private String email;
        private boolean enabled = true;
        private String role;
        private UserRole userRole;
        private String help;

        public String getPassword() {
                return password;
        }

        public void setPassword(String password){
                this.password = password;
        }


        public String getName() {
                return name;
        }

        public String getEmail() {
                return email;
        }


        public String getLogin() {
                return login;
        }


        public String getUserRole() {
                return userRole.toString();
        }

        public String getHelperUserRole(){
                return help;
        }


        public String getRole() {
                return role;
        }

        public boolean getEnabled(){ return enabled;}

}
