<!---
Artefakte der Systemdokumentation wurden mithilfe von ChatGPT (OpenAI) erstellt und manuell angepasst
-->
# Datenbankmodell Studurizer

```mermaid 
classDiagram
    class User {
        -int id
        -string username
        -string email
        -string password
        -string firstname
        -string lastname
        -int role
    }

    class Ingredient {
        -int id
        -string name
        -ENUM measuretype (kg,l,pcs)
        -float price_per_unit
    }
    
    class Shelf {
        -int id
        -int FK ingredient_id
        -DateTime expirationDate
        -int amount
        -int height
        -int FK storageRoom_id
    }
    
    class StorageRoom {
        -int id
        -int FK user_id
    }
    
    
    class Recipe {
        -int id
        -string name
        -string description
        -int preparationTime
        -int cookingTime
        -int difficulty
        -int FK user_id
    }
    
    class RecipeIngredient {
        -int id
        -int FK recipe_id
        -int FK ingredient_id
        -int amount
    }
    
    
    User "1" -- "n" StorageRoom
    User "1" -- "n" Recipe
    Recipe "1" -- "n" RecipeIngredient
    Ingredient "1" -- "n" RecipeIngredient
    StorageRoom "1" -- "n" Shelf
    User "1" -- "n" StorageRoom
    
```
