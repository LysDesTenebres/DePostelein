package com.depostelein.backend.service;
import com.depostelein.backend.model.Customer;
import com.depostelein.backend.model.User;
import com.depostelein.backend.repository.CustomerRepository;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class CustomerService {

    @Autowired
    private CustomerRepository customerRepository;

    public List<Customer> findAllCustomers() {
        return customerRepository.findAll();
    }

    public Customer addCustomer(Customer customer) {
        return customerRepository.saveAndFlush(customer);
    }

    public Customer findCustomer(int id) {
        return customerRepository.findOne(id);
    }

    public Customer changeCustomer(int id, Customer customer) {
        Customer existingCustomer = customerRepository.findOne(id);
        BeanUtils.copyProperties(customer, existingCustomer);
        return customerRepository.saveAndFlush(existingCustomer);
    }

    public Customer deleteCustomer(int id) {
        Customer existingCheckIn = findCustomer(id);
        customerRepository.delete(existingCheckIn);
        return existingCheckIn;
    }
}
