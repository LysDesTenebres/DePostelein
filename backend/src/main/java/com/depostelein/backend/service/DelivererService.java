package com.depostelein.backend.service;

import com.depostelein.backend.repository.DelivererRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class DelivererService {

    @Autowired
    private DelivererRepository delivererRepository;
}
