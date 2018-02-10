package com.depostelein.backend.repository;

import com.depostelein.backend.model.Deliverer;
import org.springframework.data.jpa.repository.JpaRepository;

public interface DelivererRepository extends JpaRepository<Deliverer, Integer> {
}
