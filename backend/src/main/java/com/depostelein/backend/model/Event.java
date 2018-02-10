package com.depostelein.backend.model;

import org.springframework.stereotype.Component;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.ManyToOne;

@Component
@Entity
public class Event {

    @Id
    private int id;
    private int guests;
    private int bread;
    private int menuId;
    private int customerId;

    public Event(){

    }

    public Event(int guests, int bread, int menuId, int customerId) {
        this.guests = guests;
        this.bread = bread;
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

    @ManyToOne (cascade = CascadeType.ALL)
    public int getMenuId() {
        return menuId;
    }

    public void setMenuId(int menuId) {
        this.menuId = menuId;
    }

    @ManyToOne(cascade = CascadeType.ALL)
    public int getCustomerId() {
        return customerId;
    }

    public void setCustomerId(int customerId) {
        this.customerId = customerId;
    }
}
