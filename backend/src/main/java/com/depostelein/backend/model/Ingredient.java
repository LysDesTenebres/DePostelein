package com.depostelein.backend.model;

import org.springframework.stereotype.Component;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.ManyToOne;

@Component
@Entity
public class Ingredient {

    @Id
    private int id;
    private String name;
    private int amount;
    private String unit;
    private int dishId;
    private int delivererId;

    public Ingredient(){

    }

    public Ingredient(String name, int amount, String unit, int dishId, int delivererId){
        this.name = name;
        this.amount = amount;
        this.unit = unit;
        this.dishId = dishId;
        this.delivererId = delivererId;
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

    public int getAmount() {
        return amount;
    }

    public void setAmount(int amount) {
        this.amount = amount;
    }

    public String getUnit() {
        return unit;
    }

    public void setUnit(String unit) {
        this.unit = unit;
    }

    public int getDishId() {
        return dishId;
    }

    public void setDishId(int dishId) {
        this.dishId = dishId;
    }

    public int getDelivererId() {
        return delivererId;
    }

    public void setDelivererId(int delivererId) {
        this.delivererId = delivererId;
    }
}
