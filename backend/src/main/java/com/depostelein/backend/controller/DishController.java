package com.depostelein.backend.controller;

import com.depostelein.backend.model.Dish;
import com.depostelein.backend.service.DishService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import java.net.URI;

@RestController
@RequestMapping("api/dish/")
public class DishController {    @Autowired
private DishService dishService;


    @RequestMapping(value = "events", method = RequestMethod.POST)
    @Secured({"ROLE_LECTURER", "ROLE_ADMIN"})
    public ResponseEntity create(@RequestBody Dish dish) {
        dishService.addDish(dish);
        return ResponseEntity.created(URI.create("/api/dish/dishes/" + dish.getId())).build();
    }

    @RequestMapping(value = "dishes/menu/{id}", method = RequestMethod.GET)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity getByMenu(@PathVariable int id) {
        return ResponseEntity.ok(dishService.findDishesByMenuId(id));
    }

    @RequestMapping(value = "dishes/menu/{id}", method = RequestMethod.GET)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity getByFunction(@PathVariable String id) {
        return ResponseEntity.ok(dishService.findDishesByFunctionId(id));
    }

    @RequestMapping(value = "dishes/{id}", method = RequestMethod.GET)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity get(@PathVariable int id) {
        return ResponseEntity.ok(dishService.findDish(id));
    }

    @RequestMapping(value = "dishes/{id}", method = RequestMethod.PUT)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity update(@PathVariable int id, @RequestBody Dish dish) {
        return ResponseEntity.ok(dishService.changeDish(id, dish));
    }

    @RequestMapping(value = "dishes/{id}", method = RequestMethod.DELETE)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity delete(@PathVariable int id) {
        return ResponseEntity.ok(dishService.deleteDish(id));
    }
}
