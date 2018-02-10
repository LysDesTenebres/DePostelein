package com.depostelein.backend.model;


import org.springframework.stereotype.Component;

import javax.persistence.*;

@Component
@Entity
public class Dish {

    private int id;
    private String name;
    private int menuId;
    private int functionId;

    public Dish(){

    }

    public Dish(String name, int menuId, int functionId){
        this.name = name;
        this.menuId = menuId;
        this.functionId = functionId;
    }

    @Id
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

    @OneToOne
    public int getMenuId() {
        return menuId;
    }

    public void setMenuId(int menuId) {
        this.menuId = menuId;
    }

    @ManyToOne(cascade = CascadeType.ALL)
    public int getFunctionId() {
        return functionId;
    }

    public void setFunctionId(int functionId) {
        this.functionId = functionId;
    }
}
