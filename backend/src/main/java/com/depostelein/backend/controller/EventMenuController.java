package com.depostelein.backend.controller;

import com.depostelein.backend.model.*;
import com.depostelein.backend.service.*;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import org.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import java.net.URI;
import java.util.LinkedList;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("api/eventMenu/")
public class EventMenuController {
    @Autowired
    private MenuService menuService;
    @Autowired
    private DishService dishService;
    @Autowired
    private IngredientService ingredientService;
    @Autowired
    private DelivererService delivererService;

    @RequestMapping(value = "admin", method = RequestMethod.POST)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity getMenuAdmin(@RequestBody String menuName) {

        Gson objGson = new Gson();

        String menuString= null;
        try {
            JSONObject object = new JSONObject(menuName);
            menuString = object.getString("menuName");
        } catch (Exception ex){

       }

        Menu menu = menuService.findMenubyName(menuString);
        List<Dish> dishes = dishService.findDishesByMenuId(menu.getId());
        List<Ingredient> ingredients = new LinkedList<>();
        List<Ingredient> list = null;
        for (Dish dish : dishes){
            list = ingredientService.findIngredientsForDish(dish.getId());
            Optional.ofNullable(list).ifPresent(ingredients::addAll);
        }
        List<Deliverer> deliverer = delivererService.findAllDeliverers();

        String json = objGson.toJson(ingredients);
        json = json + "+" +  objGson.toJson(deliverer);

        return ResponseEntity.ok(json);
    }

    @RequestMapping(value = "cook", method = RequestMethod.POST)
    @Secured({"ROLE_USER"})
    public ResponseEntity getMenuCook(@RequestBody String menuName) {

        Gson objGson = new Gson();

        String menuString= null;
        try {
            JSONObject object = new JSONObject(menuName);
            menuString = object.getString("menuName");
        } catch (Exception ex){

        }

        Menu menu = menuService.findMenubyName(menuString);
        List<Dish> dishes = dishService.findDishesByMenuId(menu.getId());
        List<Ingredient> ingredients = new LinkedList<>();
        List<Ingredient> list = null;
        for (Dish dish : dishes){
            list = ingredientService.findIngredientsForDish(dish.getId());
            Optional.ofNullable(list).ifPresent(ingredients::addAll);
        }
        String json = objGson.toJson(dishes);
        json = json + "+" + objGson.toJson(ingredients);

        return ResponseEntity.ok(json);
    }
}
