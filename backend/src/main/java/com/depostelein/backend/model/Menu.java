package com.depostelein.backend.model;


import org.springframework.stereotype.Component;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Component
@Entity
public class Menu {

    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    private int id;
    private String name;
    private double price;
    private boolean variableAmount;

    public Menu(){

    }

    public Menu(String name, double price, boolean variableAmount){
        this.name = name;
        this.price = price;
        this.variableAmount = variableAmount;
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

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public boolean isVariableAmount() {
        return variableAmount;
    }

    public void setVariableAmount(boolean variableAmount) {
        this.variableAmount = variableAmount;
    }
}
