package com.depostelein.backend.service;

import com.depostelein.backend.model.Dish;
import com.depostelein.backend.model.Event;
import com.depostelein.backend.model.User;
import com.depostelein.backend.repository.EventRepository;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.LinkedList;
import java.util.List;

@Service
public class EventService {

    @Autowired
    private EventRepository eventRepository;

    public List<Event> findAllEvents() {
        return eventRepository.findAll();
    }

    public Event addEvent(Event event) {
        return eventRepository.saveAndFlush(event);
    }

    public Event findEvent(int id) {
        return eventRepository.findOne(id);
    }

    public Event changeEvent(int id, Event event) {
        Event existingEvent = eventRepository.findOne(id);
        BeanUtils.copyProperties(event, existingEvent);
        return eventRepository.saveAndFlush(existingEvent);
    }

    public Event deleteEvent(int id) {
        Event existingEvent = findEvent(id);
        eventRepository.delete(existingEvent);
        return existingEvent;
    }

    public List<Event> findEventsByCustomer(int customerId) {
        List<Event> allEvents = eventRepository.findAll();
        List<Event> eventsForCustomerId = new LinkedList<Event>();

        allEvents.forEach(event -> {
            if (event.getCustomerId() == customerId) {
                eventsForCustomerId.add(event);
            }
        });

        return eventsForCustomerId;
    }
}
