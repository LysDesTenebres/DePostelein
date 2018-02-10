package com.depostelein.backend.model;

import org.springframework.stereotype.Component;

import javax.persistence.Entity;
import javax.persistence.Id;

@Component
@Entity
public class Customer {

    @Id
    private int id;
    private String name;
    private String surname;
    private String adress;
    private String city;
    private int postcode;

    public Customer(){

    }

    public Customer(String name, String surname, String adress, String city, int postcode){
        this.name = name;
        this.surname = surname;
        this.adress = adress;
        this.city = city;
        this.postcode = postcode;

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

    public String getSurname() {
        return surname;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }

    public String getAdress() {
        return adress;
    }

    public void setAdress(String adress) {
        this.adress = adress;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public int getPostcode() {
        return postcode;
    }

    public void setPostcode(int postcode) {
        this.postcode = postcode;
    }

}
