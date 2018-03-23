package com.depostelein.backend.controller;

import com.depostelein.backend.model.Deliverer;
import com.depostelein.backend.service.DelivererService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import java.net.URI;

@RestController
@RequestMapping("api/delivery/")
public class DelivererController {
    @Autowired
    private DelivererService delivererService;

    @RequestMapping(value = "deliverer", method = RequestMethod.GET)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity list() {
        return ResponseEntity.ok(delivererService.findAllDeliverers());
    }

    @RequestMapping(value = "deliverer", method = RequestMethod.POST)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity create(@RequestBody Deliverer deliverer) {

        return ResponseEntity.ok(delivererService.addDeliverer(deliverer));
    }

    @RequestMapping(value = "deliverer/{id}", method = RequestMethod.GET)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity get(@PathVariable int id) {
        return ResponseEntity.ok(delivererService.findDeliverer(id));
    }

    @RequestMapping(value = "deliverer/{id}", method = RequestMethod.PUT)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity update(@PathVariable int id, @RequestBody Deliverer deliverer) {
        return ResponseEntity.ok(delivererService.changeDeliverer(id, deliverer));
    }

    @RequestMapping(value = "deliverer/{id}", method = RequestMethod.DELETE)
    @Secured({"ROLE_ADMIN"})
    public ResponseEntity delete(@PathVariable int id) {
        return ResponseEntity.ok(delivererService.deleteDeliverer(id));
    }
}
