package com.android.depostelein.deposteleinandroid.Models;

import java.io.Serializable;
import java.util.Date;

public class Event implements Serializable {

    private int id;
    private int guests;
    private int bread;
    private Date date;
    private String menu;
    private String customer;
    private String location;

    public int getGuests() {
        return guests;
    }

    public int getBread() {
        return bread;
    }

    public Date getDate(){ return date;}

    public void setDate(Date date){
        this.date = date;
    }
    public String getMenu() {
        return menu;
    }

    public String getCustomer() {
        return customer;
    }

    public String getLocation() {
        return location;
    }

}

