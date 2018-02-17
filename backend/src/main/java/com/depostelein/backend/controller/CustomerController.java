package com.depostelein.backend.controller;

import com.depostelein.backend.model.Customer;
import com.depostelein.backend.service.CustomerService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import java.net.URI;

@RestController
@RequestMapping("api/customer/")
public class CustomerController {

    @Autowired
    private CustomerService customerService;

    @RequestMapping(value = "customers", method = RequestMethod.GET)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity list() {
        return ResponseEntity.ok(customerService.findAllCustomers());
    }

    @RequestMapping(value = "customers", method = RequestMethod.POST)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity create(@RequestBody Customer customer) {
        customerService.addCustomer(customer);
        return ResponseEntity.created(URI.create("/api/customer/customers/" + customer.getId())).build();
    }

    @RequestMapping(value = "customers/{id}", method = RequestMethod.GET)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity get(@PathVariable int id) {
        return ResponseEntity.ok(customerService.findCustomer(id));
    }

    @RequestMapping(value = "customers/{id}", method = RequestMethod.PUT)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity update(@PathVariable int id, @RequestBody Customer customer) {
        return ResponseEntity.ok(customerService.changeCustomer(id, customer));
    }

    @RequestMapping(value = "customers/{id}", method = RequestMethod.DELETE)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity delete(@PathVariable int id) {
        return ResponseEntity.ok(customerService.deleteCustomer(id));
    }
}

