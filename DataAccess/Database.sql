﻿CREATE DATABASE RecipeRP;

Use RecipeRP;

CREATE TABLE Ingredients(
    Id INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    [Type] INTEGER NOT NULL DEFAULT(0)
);

CREATE TABLE Recipes(
    Id INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(MAX)
);

CREATE TABLE IngredientsInRecipes(
    IngredientId INTEGER NOT NULL FOREIGN KEY REFERENCES Ingredients(Id) ON DELETE CASCADE,
    RecipeId INTEGER NOT NULL FOREIGN KEY REFERENCES Recipes(Id) ON DELETE CASCADE,
    Amount INTEGER,
    Unit Integer,
    CONSTRAINT PK_Ingredient_Recipe PRIMARY KEY (IngredientId, RecipeId)
);