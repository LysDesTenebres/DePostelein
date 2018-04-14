package com.depostelein.backend.model.Enums;

public enum UserRole {
    ADMIN ("ADMIN"),
    HAPJES ("HAPJES"),
    KOUD ("KOUD"),
    GROENTEN ("GROENTEN"),
    BEREIDINGEN ("BEREIDINGEN"),
    AARDAPPELBEREIDINGEN ("AARDAPPELBEREIDINGEN"),
    SAUZEN ("SAUZEN"),
    VIS ("VIS"),
    DESSERT ("DESSERT"),
    DRANKEN ("DRANKEN"),
    LOGISTIEK ("LOGISTIEK");

    UserRole (String type) {type = type;}
}
