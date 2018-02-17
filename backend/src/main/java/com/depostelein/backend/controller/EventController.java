package com.depostelein.backend.controller;

import com.depostelein.backend.model.Event;
import com.depostelein.backend.service.EventService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import java.net.URI;

@RestController
@RequestMapping("api/event/")
public class EventController {    @Autowired
private EventService eventService;

    @RequestMapping(value = "events", method = RequestMethod.GET)
    @Secured({"ROLE_LECTURER", "ROLE_ADMIN"})
    public ResponseEntity list() {
        return ResponseEntity.ok(eventService.findAllEvents());
    }

    @RequestMapping(value = "events", method = RequestMethod.POST)
    @Secured({"ROLE_LECTURER", "ROLE_ADMIN"})
    public ResponseEntity create(@RequestBody Event event) {
        eventService.addEvent(event);
        return ResponseEntity.created(URI.create("/api/event/events/" + event.getId())).build();
    }

    @RequestMapping(value = "events/{id}", method = RequestMethod.GET)
    @Secured({"ROLE_STUDENT", "ROLE_LECTURER", "ROLE_ADMIN"})
    public ResponseEntity get(@PathVariable int id) {
        return ResponseEntity.ok(eventService.findEvent(id));
    }

    @RequestMapping(value = "events/{id}", method = RequestMethod.PUT)
    @Secured({"ROLE_LECTURER", "ROLE_ADMIN"})
    public ResponseEntity update(@PathVariable int id, @RequestBody Event event) {
        return ResponseEntity.ok(eventService.changeEvent(id, event));
    }

    @RequestMapping(value = "events/{id}", method = RequestMethod.DELETE)
    @Secured({"ROLE_LECTURER", "ROLE_ADMIN"})
    public ResponseEntity delete(@PathVariable int id) {
        return ResponseEntity.ok(eventService.deleteEvent(id));
    }
}
