INSERT INTO user (id, name, login, password, email, role, enabled, user_role)
VALUES (NULL, 'testadmin', 'testadmin', '274c5c7103f11ebc07381acae9c804f01154e83e174b5d18816ec273d25c2906', 'verena.grabner@student.pxl.be', 'ROLE_ADMIN', TRUE, 'ADMIN');
INSERT INTO user (id, name, login, password, email, role, enabled, user_role)
VALUES (2,'hapjes','testhapjes','38d7099d1c2e32e193b0685ac709ee4d03cf140bd73e982c6c068904bb0956a9','verena.grabner@student.pxl.be','ROLE_USER',TRUE,'HAPJES');

INSERT INTO customer (id, name, surname, adress, city, postcode)
VALUES (NULL, 'Vandenberg', 'Sander', 'Teststreet 15', 'Voorbeeld', 2578);
INSERT INTO customer (id, name, surname, adress, city, postcode)
VALUES (NULL, 'Testman', 'Max', 'Teststreet 5', 'Testcity', 2345);

INSERT INTO deliverer (id, name)
VALUES (NULL, 'Testdeliverer');
INSERT INTO deliverer (id, name)
VALUES (NULL, 'Albert Heijn');

INSERT INTO menu (id, name, price, variable_amount)
VALUES (NULL, 'Testmenu', 14.5, FALSE);

INSERT INTO event (id, guests, bread, date, menu, customer, location)
VALUES (NULL, 50, 100, '2008-03-02', 'Testmenu', 'somecustomer', 'somelocation');

INSERT INTO dish(id, name, menu_id, role)
VALUES (NULL, 'testdish', 1,'KOUD');
INSERT INTO dish(id, name, menu_id, role)
VALUES (NULL, 'Spare Ribs', 1,'HAPJES');

INSERT INTO ingredient (id, name, amount, unit, dish_id, deliverer_id)
VALUES (NULL, 'testingredient', 500, 'gram', 1, 2);
INSERT INTO ingredient (id, name, amount, unit, dish_id, deliverer_id)
VALUES (NULL, 'vlees', 350, 'gram', 1, 1);
INSERT INTO ingredient (id, name, amount, unit, dish_id, deliverer_id)
VALUES (NULL, 'vlees', 700, 'gram', 2, 1);
