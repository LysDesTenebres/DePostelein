package com.depostelein.backend.service;

import com.depostelein.backend.model.Event;
import com.depostelein.backend.model.Ingredient;
import com.depostelein.backend.repository.IngredientRepository;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.LinkedList;
import java.util.List;

@Service
public class IngredientService {

    @Autowired
    private IngredientRepository ingredientRepository;

    public List<Ingredient> findAllIngredients() {
        return ingredientRepository.findAll();
    }

    public Ingredient addIngredient(Ingredient ingredient) {
        return ingredientRepository.saveAndFlush(ingredient);
    }

    public Ingredient findIngredient(int id) {
        return ingredientRepository.findOne(id);
    }

    public Ingredient changeIngredient(int id, Ingredient ingredient) {
        Ingredient existingIngredient = ingredientRepository.findOne(id);
        BeanUtils.copyProperties(ingredient, existingIngredient);
        return ingredientRepository.saveAndFlush(existingIngredient);
    }

    public Ingredient deleteIngredient(int id) {
        Ingredient existingIngredient = findIngredient(id);
        ingredientRepository.delete(existingIngredient);
        return existingIngredient;
    }

    public List<Ingredient> findIngredientsForDish(int dishId) {
        List<Ingredient> allIngredients = ingredientRepository.findAll();
        List<Ingredient> ingredientsForDishId = new LinkedList<Ingredient>();

        allIngredients.forEach(ingredient -> {
            if (ingredient.getDishId() == dishId) {
                ingredientsForDishId.add(ingredient);
            }
        });

        return ingredientsForDishId;
    }

    public List<Ingredient> findIngredientsForDeliverer(int delivererId) {
        List<Ingredient> allIngredients = ingredientRepository.findAll();
        List<Ingredient> ingredientsForDishId = new LinkedList<Ingredient>();

        allIngredients.forEach(ingredient -> {
            if (ingredient.getDelivererId() == delivererId) {
                ingredientsForDishId.add(ingredient);
            }
        });

        return ingredientsForDishId;
    }
}
