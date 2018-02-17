package com.depostelein.backend.controller;

import com.depostelein.backend.model.Menu;
import com.depostelein.backend.service.MenuService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import java.net.URI;

@RestController
@RequestMapping("api/menu/")
public class MenuController {    @Autowired
private MenuService menuService;

    @RequestMapping(value = "events", method = RequestMethod.GET)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity list() {
        return ResponseEntity.ok(menuService.findAllMenus());
    }

    @RequestMapping(value = "menus", method = RequestMethod.POST)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity create(@RequestBody Menu menu) {
        menuService.addMenu(menu);
        return ResponseEntity.created(URI.create("/api/menu/menus/" + menu.getId())).build();
    }

    @RequestMapping(value = "menus/{id}", method = RequestMethod.GET)
    @Secured({"ROLE_STUDENT", "ROLE_LECTURER", "ROLE_ADMIN"})
    public ResponseEntity get(@PathVariable int id) {
        return ResponseEntity.ok(menuService.findMenu(id));
    }

    @RequestMapping(value = "events/{id}", method = RequestMethod.PUT)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity update(@PathVariable int id, @RequestBody Menu menu) {
        return ResponseEntity.ok(menuService.changeMenu(id, menu));
    }

    @RequestMapping(value = "menus/{id}", method = RequestMethod.DELETE)
    @Secured({"ROLE_LECTURER", "ROLE_ADMIN"})
    public ResponseEntity delete(@PathVariable int id) {
        return ResponseEntity.ok(menuService.deleteMenu(id));
    }
}
