INSERT INTO user (id, name, login, password, salt, email, role, enabled, user_role)
VALUES (NULL, 'testadmin', 'testadmin', '9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08', 'salt', 'verena.grabner@student.pxl.be', 'ROLE_ADMIN', TRUE, 'COLD');

INSERT INTO customer (id, name, surname, adress, city, postcode)
VALUES (NULL, 'Max', 'Testman', 'Teststreet 5', 'Testcity', 2345);

INSERT INTO deliverer (id, name)
VALUES (NULL, 'Testdeliverer');

INSERT INTO menu (id, name, price, variable_amount)
VALUES (NULL, 'Testmenu', 14.5, FALSE);

INSERT INTO event (id, guests, bread, date, menu, customer, location)
VALUES (NULL, 50, 100, '2008-03-02', 'Testmenu', 'somecustomer', 'somelocation');

INSERT INTO dish(id, name, menu_id, role)
VALUES (NULL, 'testdish', 1,'ROLE_ADMIN');

INSERT INTO ingredient (id, name, amount, unit, dish_id, deliverer_id)
VALUES (NULL, 'testingredient', 500, 'gram', 1, 1);
