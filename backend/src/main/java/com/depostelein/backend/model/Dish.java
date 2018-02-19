package com.depostelein.backend.model;

import org.springframework.stereotype.Component;
import javax.persistence.*;

@Component
@Entity
public class Dish {

    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    private int id;
    private String name;
    private int menuId;
    private String role;


    public Dish(){

    }

    public Dish(String name, int menuId, String functionId){
        this.name = name;
        this.menuId = menuId;
        this.role = functionId;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }


    //@ManyToOne (cascade = CascadeType.ALL, targetEntity = Menu.class)
    public int getMenuId() {
        return menuId;
    }

    public void setMenuId(int menuId) {
        this.menuId = menuId;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String functionId) {
        this.role = functionId;
    }
}
