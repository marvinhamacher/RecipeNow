<!---
Artefakte der Systemdokumentation wurden mithilfe von ChatGPT (OpenAI) erstellt und manuell angepasst
-->
# Datenbankmodell RecipeNow

```mermaid 
classDiagram

    class AspNetUsers {
        string Id PK
        string UserName
        string NormalizedUserName
        string Email
        string NormalizedEmail
        bool EmailConfirmed
        string PasswordHash
        string SecurityStamp
        string ConcurrencyStamp
        string PhoneNumber
        bool PhoneNumberConfirmed
        bool TwoFactorEnabled
        DateTime LockoutEnd
        bool LockoutEnabled
        int AccessFailedCount
    }

    class StorageRooms {
        int Id PK
        string UserId FK
        string Name
    }

    class Shelves {
        int Id PK
        string ContentDescription
        int Height
        int Width
        int StorageRoomId FK
    }

    class Ingredients {
        int Id PK
        string Name
        float PricePerUnit
        int Measurement
        string ImagePath
    }

    class ShelfIngredients {
        int Id PK
        DateTime ExpirationDate
        int ShelfId FK
        int IngredientId FK
        string Amount
        int Row
        int Column
    }

    class Recipes {
        int Id PK
        string Name
        string Description
        string CookingInstructions
        int PreparationTime
        int CookingTime
        int CookingDifficulty
        string UserId FK
        string ImagePath
    }

    class RecipeIngredients {
        int Id PK
        int RecipeId FK
        int IngredientId FK
        string Amount
    }

    class RecipeImages {
        int Id PK
        int RecipeId FK
        string ImagePath
        bool IsPrimary
    }

    AspNetUsers "1" -- "n" StorageRooms
    AspNetUsers "1" -- "n" Recipes

    StorageRooms "1" -- "n" Shelves
    Shelves "1" -- "n" ShelfIngredients

    Ingredients "1" -- "n" ShelfIngredients
    Ingredients "1" -- "n" RecipeIngredients

    Recipes "1" -- "n" RecipeIngredients
    Recipes "1" -- "n" RecipeImages
```
