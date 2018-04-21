package com.android.depostelein.deposteleinandroid.Models;

public class Ingredients {

    private int id;
    private String name;
    private int amount;
    private String unit;
    private int dishId;
    private int delivererId;

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public int getAmount() {
        return amount;
    }

    public String getUnit() {
        return unit;
    }

    public int getDishId() {
        return dishId;
    }

    public int getDelivererId() {
        return delivererId;
    }
}
