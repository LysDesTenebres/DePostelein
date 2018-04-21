package com.depostelein.backend.service;

import com.depostelein.backend.model.Dish;
import com.depostelein.backend.model.Menu;
import com.depostelein.backend.model.User;
import com.depostelein.backend.repository.MenuRepository;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class MenuService {

    @Autowired
    private MenuRepository menuRepository;

    public List<Menu> findAllMenus() {
        return menuRepository.findAll();
    }

    public Menu addMenu(Menu menu) {
        return menuRepository.save(menu);
    }

    public Menu findMenu(int id) {
        return menuRepository.findOne(id);
    }

    public Menu findMenubyName(String name){
        List<Menu> menus = menuRepository.findAll();
        Menu menuEvent = null;

        for (Menu menu : menus){
            if (menu.getName().equals(name)){
                menuEvent = menu;
            }
        }
        return menuEvent;
    }

    public Menu changeMenu(int id, Menu menu) {
        Menu existingMenu = menuRepository.findOne(id);
        BeanUtils.copyProperties(menu, existingMenu);
        return menuRepository.saveAndFlush(existingMenu);
    }

    public Menu deleteMenu(int id) {
        Menu existingMenu = findMenu(id);
        menuRepository.delete(existingMenu);
        return existingMenu;
    }


}
