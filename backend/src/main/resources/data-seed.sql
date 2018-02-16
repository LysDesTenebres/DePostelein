INSERT INTO user (id, name, login, password, salt, function)
VALUES (NULL, testadmin, test, test, salt, ROLE_ADMIN);

INSERT INTO customer (id, name, surname, adress, city, postcode)
VALUES (NULL, Max, Testman, Teststreet 5, Testcity, 2345);

INSERT INTO deliverer (id, name)
VALUES (NULL, Testdeliverer);

INSERT INTO menu (id, name, price, variable_amount)
VALUES (NULL, Testmenu, 14.5, FALSE);

INSERT INTO event (id, guests, bread, menu_id, customer_id)
VALUES (NULL, 50, 100, 1, 1)

INSERT INTO dish(id, name, menu_id, function_id)
VALUES (NULL, testdish, 1, ROLE_ADMIN)

INSERT INTO ingredient (id, name, amount, unit, dish_id, deliverer_id)
VALUES (NULL, testingredient, 500, gram, 1, 1)
