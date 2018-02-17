package com.depostelein.backend.service;

import com.depostelein.backend.model.Deliverer;
import com.depostelein.backend.repository.DelivererRepository;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class DelivererService {

    @Autowired
    private DelivererRepository delivererRepository;

    public List<Deliverer> findAllDeliverers() {
        return delivererRepository.findAll();
    }

    public Deliverer addDeliverer(Deliverer deliverer) {
        return delivererRepository.saveAndFlush(deliverer);
    }

    public Deliverer findDeliverer(int id) {
        return delivererRepository.findOne(id);
    }

    public Deliverer changeDeliverer(int id, Deliverer deliverer) {
        Deliverer existingDeliverer = delivererRepository.findOne(id);
        BeanUtils.copyProperties(deliverer, existingDeliverer);
        return delivererRepository.saveAndFlush(existingDeliverer);
    }

    public Deliverer deleteDeliverer(int id) {
        Deliverer existingCheckIn = findDeliverer(id);
        delivererRepository.delete(existingCheckIn);
        return existingCheckIn;
    }
}
