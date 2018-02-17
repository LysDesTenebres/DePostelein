package com.depostelein.backend.service;

import com.depostelein.backend.model.Dish;
import com.depostelein.backend.model.User;
import com.depostelein.backend.repository.DishRepository;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.LinkedList;
import java.util.List;

@Service
public class DishService {

    @Autowired
    private DishRepository dishRepository;

    public List<Dish> findAllUDishes() {
        return dishRepository.findAll();
    }

    public Dish addDish(Dish dish) {
        return dishRepository.saveAndFlush(dish);
    }

    public Dish findDish(int id) {
        return dishRepository.findOne(id);
    }

    public Dish changeDish(int id, Dish dish) {
        Dish existingDish = dishRepository.findOne(id);
        BeanUtils.copyProperties(dish, existingDish);
        return dishRepository.saveAndFlush(existingDish);
    }

    public Dish deleteDish(int id) {
        Dish existingDish = findDish(id);
        dishRepository.delete(existingDish);
        return existingDish;
    }

    public List<Dish> findDishesByMenuId(int menuId) {
        List<Dish> allDishes = dishRepository.findAll();
        List<Dish> dishesforMenuId = new LinkedList<Dish>();

        allDishes.forEach(dish -> {
            if (dish.getMenuId() == menuId) {
                dishesforMenuId.add(dish);
            }
        });

        return dishesforMenuId;
    }

    public List<Dish> findDishesByFunctionId(String role) {
        List<Dish> allDishes = dishRepository.findAll();
        List<Dish> dishesforFunctionId = new LinkedList<Dish>();

        allDishes.forEach(dish -> {
            if (dish.getRole() == role) {
                dishesforFunctionId.add(dish);
            }
        });

        return dishesforFunctionId;
    }
}
