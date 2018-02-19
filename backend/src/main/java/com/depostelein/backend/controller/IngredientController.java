package com.depostelein.backend.controller;

import com.depostelein.backend.model.Ingredient;
import com.depostelein.backend.service.IngredientService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import java.net.URI;

@RestController
@RequestMapping("api/ingredient/")
public class IngredientController {    @Autowired
private IngredientService ingredientService;


    @RequestMapping(value = "ingredients", method = RequestMethod.GET)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity list() {
        return ResponseEntity.ok(ingredientService.findAllIngredients());
    }

    @RequestMapping(value = "ingredients", method = RequestMethod.POST)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity create(@RequestBody Ingredient ingredient) {
        ingredientService.addIngredient(ingredient);
        return ResponseEntity.created(URI.create("/api/ingredient/ingredients/" + ingredient.getId())).build();
    }

    @RequestMapping(value = "ingredients/dish/{id}", method = RequestMethod.GET)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity getByDish(@PathVariable int id) {
        return ResponseEntity.ok(ingredientService.findIngredientsForDish(id));
    }

    @RequestMapping(value = "ingredients/deliverer/{id}", method = RequestMethod.GET)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity getByDeliverer(@PathVariable int id) {
        return ResponseEntity.ok(ingredientService.findIngredientsForDeliverer(id));
    }

    @RequestMapping(value = "ingredients/{id}", method = RequestMethod.GET)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity get(@PathVariable int id) {
        return ResponseEntity.ok(ingredientService.findIngredient(id));
    }

    @RequestMapping(value = "ingredients/{id}", method = RequestMethod.PUT)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity update(@PathVariable int id, @RequestBody Ingredient ingredient) {
        return ResponseEntity.ok(ingredientService.changeIngredient(id, ingredient));
    }

    @RequestMapping(value = "ingredients/{id}", method = RequestMethod.DELETE)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity delete(@PathVariable int id) {
        return ResponseEntity.ok(ingredientService.deleteIngredient(id));
    }
}
