package com.depostelein.backend.model;

import org.springframework.stereotype.Component;

import javax.persistence.*;
import java.util.Date;

@Component
@Entity
public class Event {

    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    private int id;
    private int guests;
    private int bread;
    private Date date;
    private String menu;
    private String customer;
    private String location;

    public Event(){

    }

    public Event(int guests, int bread, Date date, String menu, String customer) {
        this.guests = guests;
        this.bread = bread;
        this.date = date;
        this.menu = menu;
        this.customer = customer;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getGuests() {
        return guests;
    }

    public void setGuests(int guests) {
        this.guests = guests;
    }

    public int getBread() {
        return bread;
    }

    public void setBread(int bread) {
        this.bread = bread;
    }

    public void setDate(Date date) { this.date = date;}

    public Date getDate(){ return date;}

    public String getMenu() {
        return menu;
    }

    public void setMenu(String menu) {
        this.menu = menu;
    }

    public String getCustomer() {
        return customer;
    }

    public void setCustomerId(int customerId) {
        this.customer = customer;
    }

    public void setCustomer(String customer) {
        this.customer = customer;
    }

    public String getLocation() {
        return location;
    }

    public void setLocation(String location) {
        this.location = location;
    }
}
