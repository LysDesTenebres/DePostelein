package com.depostelein.backend.model;

import org.springframework.stereotype.Component;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.ManyToOne;
import java.util.Date;

@Component
@Entity
public class Event {

    @Id
    private int id;
    private int guests;
    private int bread;
    private Date date;
    private int menuId;
    private int customerId;

    public Event(){

    }

    public Event(int guests, int bread, Date date, int menuId, int customerId) {
        this.guests = guests;
        this.bread = bread;
        this.date = date;
        this.menuId = menuId;
        this.customerId = customerId;
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

    public int getMenuId() {
        return menuId;
    }

    public void setMenuId(int menuId) {
        this.menuId = menuId;
    }

    public int getCustomerId() {
        return customerId;
    }

    public void setCustomerId(int customerId) {
        this.customerId = customerId;
    }
}
