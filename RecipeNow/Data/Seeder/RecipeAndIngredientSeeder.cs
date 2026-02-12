using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeNow.Data.Contexts;
using RecipeNow.Data.Entities.RecipeSystem;
using RecipeNow.Data.Enumerators;

namespace RecipeNow.Data.Seeder;

public class RecipeAndIngredientSeeder
{
    public static async Task SeedIngredientsAsync(AppDbContext db, CancellationToken ct = default)
    {
        await db.Database.MigrateAsync(ct);

        var ingredientsToSeed = new[]
        {
            new
            {
                Name = "Zucker", PricePerUnit = 2.8, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/zucker.png"
            },
            new
            {
                Name = "Mehl", PricePerUnit = 1.9, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/mehl.png"
            },
            new
            {
                Name = "Butter", PricePerUnit = 8.5, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/butter.png"
            },
            new
            {
                Name = "Milch", PricePerUnit = 1.2, MeasurementType = MeasurementType.Liter,
                ImagePath = "static/Images/IngredientStatic/milch.png"
            },
            new
            {
                Name = "Olivenöl", PricePerUnit = 9.9, MeasurementType = MeasurementType.Liter,
                ImagePath = "static/Images/IngredientStatic/olivenoel.png"
            },
            new
            {
                Name = "Sonnenblumenöl", PricePerUnit = 4.2, MeasurementType = MeasurementType.Liter,
                ImagePath = "static/Images/IngredientStatic/sonnenblumenoel.png"
            },
            new
            {
                Name = "Eier", PricePerUnit = 0.35, MeasurementType = MeasurementType.Pieces,
                ImagePath = "static/Images/IngredientStatic/eier.png"
            },
            new
            {
                Name = "Tomaten", PricePerUnit = 3.2, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/tomaten.png"
            },
            new
            {
                Name = "Gurken", PricePerUnit = 2.4, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/gurken.png"
            },
            new
            {
                Name = "Paprika", PricePerUnit = 4.1, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/paprika.png"
            },
            new
            {
                Name = "Zwiebeln", PricePerUnit = 2.0, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/zwiebeln.png"
            },
            new
            {
                Name = "Knoblauch", PricePerUnit = 6.5, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/knoblauch.png"
            },
            new
            {
                Name = "Karotten", PricePerUnit = 1.8, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/karotten.png"
            },
            new
            {
                Name = "Kartoffeln", PricePerUnit = 1.6, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/kartoffeln.png"
            },
            new
            {
                Name = "Reis", PricePerUnit = 2.3, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/reis.png"
            },
            new
            {
                Name = "Nudeln", PricePerUnit = 1.7, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/nudeln.png"
            },
            new
            {
                Name = "Hähnchenbrust", PricePerUnit = 11.5, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/haehnchenbrust.png"
            },
            new
            {
                Name = "Rinderhack", PricePerUnit = 13.9, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/rinderhack.png"
            },
            new
            {
                Name = "Schweinefleisch", PricePerUnit = 9.8, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/schweinefleisch.png"
            },
            new
            {
                Name = "Lachs", PricePerUnit = 18.5, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/lachs.png"
            },
            new
            {
                Name = "Thunfisch", PricePerUnit = 15.2, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/thunfisch.png"
            },
            new
            {
                Name = "Käse", PricePerUnit = 10.4, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/kaese.png"
            },
            new
            {
                Name = "Joghurt", PricePerUnit = 1.5, MeasurementType = MeasurementType.Liter,
                ImagePath = "static/Images/IngredientStatic/joghurt.png"
            },
            new
            {
                Name = "Sahne", PricePerUnit = 3.6, MeasurementType = MeasurementType.Liter,
                ImagePath = "static/Images/IngredientStatic/sahne.png"
            },
            new
            {
                Name = "Honig", PricePerUnit = 12.0, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/honig.png"
            },
            new
            {
                Name = "Essig", PricePerUnit = 2.2, MeasurementType = MeasurementType.Liter,
                ImagePath = "static/Images/IngredientStatic/essig.png"
            },
            new
            {
                Name = "Hefe", PricePerUnit = 0.25, MeasurementType = MeasurementType.Pieces,
                ImagePath = "static/Images/IngredientStatic/hefe.png"
            },
            new
            {
                Name = "Äpfel", PricePerUnit = 2.9, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/aepfel.png"
            },
            new
            {
                Name = "Bananen", PricePerUnit = 2.1, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/bananen.png"
            },
            new
            {
                Name = "Orangen", PricePerUnit = 3.3, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/orangen.png"
            },
            new
            {
                Name = "Zitronen", PricePerUnit = 3.8, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/zitronen.png"
            },
            new
            {
                Name = "Avocado", PricePerUnit = 1.8, MeasurementType = MeasurementType.Pieces,
                ImagePath = "static/Images/IngredientStatic/avocado.png"
            },
            new
            {
                Name = "Brokkoli", PricePerUnit = 3.7, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/brokkoli.png"
            },
            new
            {
                Name = "Spinat", PricePerUnit = 4.5, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/spinat.png"
            },
            new
            {
                Name = "Champignons", PricePerUnit = 5.2, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/champignons.png"
            },
            new
            {
                Name = "Mais", PricePerUnit = 0.9, MeasurementType = MeasurementType.Pieces,
                ImagePath = "static/Images/IngredientStatic/mais.png"
            },
            new
            {
                Name = "Erbsen", PricePerUnit = 2.4, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/erbsen.png"
            },
            new
            {
                Name = "Bohnen", PricePerUnit = 2.6, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/bohnen.png"
            },
            new
            {
                Name = "Mandeln", PricePerUnit = 14.0, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/mandeln.png"
            },
            new
            {
                Name = "Haselnüsse", PricePerUnit = 16.5, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/haselnuesse.png"
            },
            new
            {
                Name = "Walnüsse", PricePerUnit = 15.8, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/walnuesse.png"
            },
            new
            {
                Name = "Kokosmilch", PricePerUnit = 3.4, MeasurementType = MeasurementType.Liter,
                ImagePath = "static/Images/IngredientStatic/kokosmilch.png"
            },
            new
            {
                Name = "Sojasauce", PricePerUnit = 5.6, MeasurementType = MeasurementType.Liter,
                ImagePath = "static/Images/IngredientStatic/sojasauce.png"
            },
            new
            {
                Name = "Ketchup", PricePerUnit = 3.1, MeasurementType = MeasurementType.Liter,
                ImagePath = "static/Images/IngredientStatic/ketchup.png"
            },
            new
            {
                Name = "Senf", PricePerUnit = 2.7, MeasurementType = MeasurementType.Liter,
                ImagePath = "static/Images/IngredientStatic/senf.png"
            },
            new
            {
                Name = "Mayonnaise", PricePerUnit = 4.0, MeasurementType = MeasurementType.Liter,
                ImagePath = "static/Images/IngredientStatic/mayonnaise.png"
            },
            new
            {
                Name = "Mineralwasser", PricePerUnit = 0.8, MeasurementType = MeasurementType.Liter,
                ImagePath = "static/Images/IngredientStatic/mineralwasser.png"
            },
            new
            {
                Name = "Kaffeebohnen", PricePerUnit = 18.0, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/kaffeebohnen.png"
            },
            new
            {
                Name = "Schokolade", PricePerUnit = 7.5, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/schokolade.png"
            },
            new
            {
                Name = "Vanillebohnen", PricePerUnit = 0.2, MeasurementType = MeasurementType.Pieces,
                ImagePath = "static/Images/IngredientStatic/vanille.png"
            },
            new
            {
                Name = "Zimt", PricePerUnit = 9.0, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/zimt.png"
            },
            new
            {
                Name = "Pfeffer", PricePerUnit = 12.5, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/pfeffer.png"
            },
            new
            {
                Name = "Chili", PricePerUnit = 10.8, MeasurementType = MeasurementType.Kilogram,
                ImagePath = "static/Images/IngredientStatic/chili.png"
            },
            new
            {
                Name = "Basilikum", PricePerUnit = 1.2, MeasurementType = MeasurementType.Pieces,
                ImagePath = "static/Images/IngredientStatic/basilikum.png"
            },
            new
            {
                Name = "Petersilie", PricePerUnit = 1.1, MeasurementType = MeasurementType.Pieces,
                ImagePath = "static/Images/IngredientStatic/petersilie.png"
            },
        };

        foreach (var x in ingredientsToSeed)
        {
            var existing = await db.Ingredients
                .SingleOrDefaultAsync(i => i.Name == x.Name, ct);

            if (existing is null)
            {
                db.Ingredients.Add(new Ingredient
                {
                    Name = x.Name,
                    PricePerUnit = (float)x.PricePerUnit,
                    ImagePath = x.ImagePath,
                    Measurement = x.MeasurementType,
                });
            }
            else
            {
                // Update (repeatable)
                existing.Name = x.Name;
                existing.PricePerUnit = (float)x.PricePerUnit;
                existing.ImagePath = x.ImagePath;
                existing.Measurement = x.MeasurementType;
            }
        }

        await db.SaveChangesAsync(ct);
    }

    public static async Task SeedUsersAsync<TUser>(
        UserManager<TUser> userManager,
        string seedPassword,
        CancellationToken ct = default)
        where TUser : IdentityUser, new()
    {
        var users = new (string Email, string UserName)[]
        {
            ("user1@example.test", "user1"),
            ("user2@example.test", "user2"),
            ("user3@example.test", "user3"),
            ("user4@example.test", "user4"),
            ("user5@example.test", "user5"),
        };

        foreach (var u in users)
        {
            // repeatable: finde anhand Email oder Username
            var existing = await userManager.FindByEmailAsync(u.Email);
            if (existing is null)
            {
                var newUser = new TUser
                {
                    Email = u.Email,
                    UserName = u.UserName,
                    EmailConfirmed = true
                };

                var createResult = await userManager.CreateAsync(newUser, seedPassword);
                if (!createResult.Succeeded)
                {
                    var msg = string.Join("; ", createResult.Errors.Select(e => $"{e.Code}:{e.Description}"));
                    throw new InvalidOperationException($"Failed to create seed user {u.Email}: {msg}");
                }
            }
        }
    }

    public static async Task SeedRecipesAsync(
        AppDbContext db,
        UserManager<IdentityUser> userManager,
        CancellationToken ct = default)
    {
        var seedEmails = new[]
        {
            "user1@example.test",
            "user2@example.test",
            "user3@example.test",
            "user4@example.test",
            "user5@example.test",
        };

        var users = new List<IdentityUser>();
        foreach (var email in seedEmails)
        {
            var u = await userManager.FindByEmailAsync(email);
            if (u is not null)
                users.Add(u);
        }

        if (users.Count == 0)
            throw new InvalidOperationException("No seed users found. Seed users first.");

        async Task<int> IngredientId(string name)
        {
            var ing = await db.Ingredients.AsNoTracking().SingleOrDefaultAsync(i => i.Name == name, ct);
            return ing?.Id ?? throw new InvalidOperationException(
                $"Missing ingredient '{name}'. Add it to Ingredient seeding first.");
        }

        var recipes = new[]
        {
            new
            {
                Name = "Spaghetti Aglio e Olio",
                Description = "Einfach, schnell, knoblauchig – Klassiker aus Neapel.",
                Prep = 10,
                Cook = 12,
                Difficulty = CookingDifficulty.Easy,
                ImagePath = "/images/recipes/spaghetti-aglio-e-olio.jpg",
                Ingredients = new (string Name, int Amount)[]
                {
                    ("Spaghetti", 200),
                    ("Olive Oil", 30),
                    ("Garlic", 8),
                    ("Salt", 5),
                    ("Pepper", 2),
                }
            },
            new
            {
                Name = "Tomaten-Basilikum-Pasta",
                Description = "Frische Tomaten, Basilikum und ein Hauch Parmesan.",
                Prep = 10,
                Cook = 18,
                Difficulty = CookingDifficulty.Easy,
                ImagePath = "/images/recipes/tomato-basil-pasta.jpg",
                Ingredients = new (string Name, int Amount)[]
                {
                    ("Spaghetti", 200),
                    ("Tomato", 250),
                    ("Olive Oil", 20),
                    ("Garlic", 6),
                    ("Basil", 10),
                    ("Salt", 5),
                }
            },
            new
            {
                Name = "Pancakes",
                Description = "Fluffig, goldbraun – perfekt fürs Wochenende.",
                Prep = 10,
                Cook = 15,
                Difficulty = CookingDifficulty.Easy,
                ImagePath = "/images/recipes/pancakes.jpg",
                Ingredients = new (string Name, int Amount)[]
                {
                    ("Flour", 200),
                    ("Milk", 250),
                    ("Eggs", 2),
                    ("Butter", 30),
                    ("Sugar", 25),
                    ("Salt", 2),
                }
            },
            new
            {
                Name = "Rührei mit Kräutern",
                Description = "Cremiges Rührei mit frischen Kräutern.",
                Prep = 5,
                Cook = 7,
                Difficulty = CookingDifficulty.Easy,
                ImagePath = "/images/recipes/herb-scrambled-eggs.jpg",
                Ingredients = new (string Name, int Amount)[]
                {
                    ("Eggs", 3),
                    ("Butter", 15),
                    ("Salt", 2),
                    ("Pepper", 1),
                }
            },
            new
            {
                Name = "Hähnchen-Curry mit Reis",
                Description = "Wärmendes Curry, mild bis pikant skalierbar.",
                Prep = 15,
                Cook = 25,
                Difficulty = CookingDifficulty.Medium,
                ImagePath = "/images/recipes/chicken-curry-rice.jpg",
                Ingredients = new (string Name, int Amount)[]
                {
                    ("Chicken Breast", 300),
                    ("Onion", 120),
                    ("Garlic", 6),
                    ("Curry Powder", 10),
                    ("Olive Oil", 15),
                    ("Salt", 5),
                    ("Rice", 200),
                }
            },
            new
            {
                Name = "Tomatensuppe",
                Description = "Samtige Suppe, ideal mit etwas Pfeffer und Basilikum.",
                Prep = 10,
                Cook = 20,
                Difficulty = CookingDifficulty.Easy,
                ImagePath = "/images/recipes/tomato-soup.jpg",
                Ingredients = new (string Name, int Amount)[]
                {
                    ("Tomato", 500),
                    ("Onion", 120),
                    ("Garlic", 6),
                    ("Olive Oil", 15),
                    ("Salt", 6),
                    ("Pepper", 2),
                    ("Basil", 8),
                }
            },
            new
            {
                Name = "Ofenkartoffeln",
                Description = "Knusprig außen, weich innen – Ofen macht die Arbeit.",
                Prep = 10,
                Cook = 35,
                Difficulty = CookingDifficulty.Easy,
                ImagePath = "/images/recipes/oven-potatoes.jpg",
                Ingredients = new (string Name, int Amount)[]
                {
                    ("Potato", 600),
                    ("Olive Oil", 20),
                    ("Salt", 6),
                    ("Pepper", 2),
                }
            },
            new
            {
                Name = "Zitronen-Hähnchen",
                Description = "Frisch, leicht, perfekt mit Reis oder Pasta.",
                Prep = 10,
                Cook = 20,
                Difficulty = CookingDifficulty.Medium,
                ImagePath = "/images/recipes/lemon-chicken.jpg",
                Ingredients = new (string Name, int Amount)[]
                {
                    ("Chicken Breast", 300),
                    ("Lemon", 1),
                    ("Olive Oil", 15),
                    ("Garlic", 4),
                    ("Salt", 5),
                    ("Pepper", 2),
                }
            },
            new
            {
                Name = "Caprese-Salat",
                Description = "Tomate, Basilikum, Öl – simpel und genial.",
                Prep = 8,
                Cook = 0,
                Difficulty = CookingDifficulty.Easy,
                ImagePath = "/images/recipes/caprese-salad.jpg",
                Ingredients = new (string Name, int Amount)[]
                {
                    ("Tomato", 300),
                    ("Basil", 10),
                    ("Olive Oil", 15),
                    ("Salt", 4),
                    ("Pepper", 2),
                }
            },
            new
            {
                Name = "Knoblauchbrot",
                Description = "Buttrig-knusprig – Beilage oder Snack.",
                Prep = 8,
                Cook = 12,
                Difficulty = CookingDifficulty.Easy,
                ImagePath = "/images/recipes/garlic-bread.jpg",
                Ingredients = new (string Name, int Amount)[]
                {
                    ("Bread", 250),
                    ("Butter", 40),
                    ("Garlic", 8),
                    ("Salt", 3),
                }
            },
        };

        for (var index = 0; index < recipes.Length; index++)
        {
            var r = recipes[index];
            var ownerUserId = users[index % users.Count].Id;

            var existing = await db.Recipes
                .Include(x => x.RecipeIngredients)
                .SingleOrDefaultAsync(x => x.Name == r.Name, ct);

            if (existing is null)
            {
                existing = new Recipe
                {
                    Name = r.Name,
                    Images = new List<RecipeImage>(),
                    RecipeIngredients = new List<RecipeIngredient>(),
                    ImagePath = r.ImagePath,
                    UserId = ownerUserId,
                    Description = r.Description,
                    PreparationTime = r.Prep,
                    CookingTime = r.Cook,
                    CookingDifficulty = r.Difficulty,
                };
                existing.Images.Add(new RecipeImage
                {
                    ImagePath = r.ImagePath,
                    IsPrimary = true
                });
                db.Recipes.Add(existing);
            }
            else
            {
                existing.UserId = ownerUserId;
                existing.Description = r.Description;
                existing.PreparationTime = r.Prep;
                existing.CookingTime = r.Cook;
                existing.CookingDifficulty = r.Difficulty;
                existing.ImagePath = r.ImagePath;

                existing.RecipeIngredients ??= new List<RecipeIngredient>();
                existing.Images ??= new List<RecipeImage>();

                // repeatable: Zutatenliste sauber "resetten"
                db.RecipeIngredients.RemoveRange(existing.RecipeIngredients);
                existing.RecipeIngredients.Clear();
                existing.Images.Add(new RecipeImage
                {
                    ImagePath = r.ImagePath,
                    IsPrimary = true
                });
            }

            foreach (var (ingredientName, amount) in r.Ingredients)
            {
                var ing = await db.Ingredients.FindAsync(ingredientName, ct);
                existing.RecipeIngredients.Add(new RecipeIngredient
                {
                    Recipe = existing,
                    RecipeId = existing.Id,
                    IngredientId = await IngredientId(ing.Name),
                    Ingredient = ing,
                    Amount = amount
                });
            }
        }

        await db.SaveChangesAsync(ct);
    }
}