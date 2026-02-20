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
                Name = "Zucker", PricePerUnit = 0.0028, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/zucker.png"
            },
            new
            {
                Name = "Salz", PricePerUnit = 0.0008, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/salz.png"
            },
            new
            {
                Name = "Mehl", PricePerUnit = 0.0019, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/mehl.png"
            },
            new
            {
                Name = "Butter", PricePerUnit = 0.0085, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/butter.png"
            },
            new
            {
                Name = "Milch", PricePerUnit = 0.0012, MeasurementType = MeasurementType.Milliliter,
                ImagePath = "static/Images/IngredientStatic/milch.png"
            },
            new
            {
                Name = "Olivenöl", PricePerUnit = 0.0099, MeasurementType = MeasurementType.Milliliter,
                ImagePath = "static/Images/IngredientStatic/olivenoel.png"
            },
            new
            {
                Name = "Sonnenblumenöl", PricePerUnit = 0.0042, MeasurementType = MeasurementType.Milliliter,
                ImagePath = "static/Images/IngredientStatic/sonnenblumenoel.png"
            },
            new
            {
                Name = "Eier", PricePerUnit = 0.35, MeasurementType = MeasurementType.Pieces,
                ImagePath = "static/Images/IngredientStatic/eier.png"
            },
            new
            {
                Name = "Tomaten", PricePerUnit = 0.0032, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/tomaten.png"
            },
            new
            {
                Name = "Gurken", PricePerUnit = 0.0024, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/gurken.png"
            },
            new
            {
                Name = "Paprika", PricePerUnit = 0.0041, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/paprika.png"
            },
            new
            {
                Name = "Zwiebeln", PricePerUnit = 0.0020, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/zwiebeln.png"
            },
            new
            {
                Name = "Knoblauch", PricePerUnit = 0.0065, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/knoblauch.png"
            },
            new
            {
                Name = "Karotten", PricePerUnit = 0.0018, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/karotten.png"
            },
            new
            {
                Name = "Kartoffeln", PricePerUnit = 0.0016, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/kartoffeln.png"
            },
            new
            {
                Name = "Reis", PricePerUnit = 0.0023, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/reis.png"
            },
            new
            {
                Name = "Nudeln", PricePerUnit = 0.0017, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/nudeln.png"
            },
            new
            {
                Name = "Hähnchenbrust", PricePerUnit = 0.0115, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/haehnchenbrust.png"
            },
            new
            {
                Name = "Rinderhack", PricePerUnit = 0.0139, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/rinderhack.png"
            },
            new
            {
                Name = "Schweinefleisch", PricePerUnit = 0.0098, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/schweinefleisch.png"
            },
            new
            {
                Name = "Lachs", PricePerUnit = 0.0185, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/lachs.png"
            },
            new
            {
                Name = "Thunfisch", PricePerUnit = 0.0152, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/thunfisch.png"
            },
            new
            {
                Name = "Käse", PricePerUnit = 0.0104, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/kaese.png"
            },
            new
            {
                Name = "Joghurt", PricePerUnit = 0.0015, MeasurementType = MeasurementType.Milliliter,
                ImagePath = "static/Images/IngredientStatic/joghurt.png"
            },
            new
            {
                Name = "Sahne", PricePerUnit = 0.0036, MeasurementType = MeasurementType.Milliliter,
                ImagePath = "static/Images/IngredientStatic/sahne.png"
            },
            new
            {
                Name = "Honig", PricePerUnit = 0.0120, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/honig.png"
            },
            new
            {
                Name = "Essig", PricePerUnit = 0.0022, MeasurementType = MeasurementType.Milliliter,
                ImagePath = "static/Images/IngredientStatic/essig.png"
            },
            new
            {
                Name = "Hefe", PricePerUnit = 0.25, MeasurementType = MeasurementType.Pieces,
                ImagePath = "static/Images/IngredientStatic/hefe.png"
            },
            new
            {
                Name = "Äpfel", PricePerUnit = 0.0029, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/aepfel.png"
            },
            new
            {
                Name = "Bananen", PricePerUnit = 0.0021, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/bananen.png"
            },
            new
            {
                Name = "Orangen", PricePerUnit = 0.0033, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/orangen.png"
            },
            new
            {
                Name = "Zitronen", PricePerUnit = 0.0038, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/zitronen.png"
            },
            new
            {
                Name = "Avocado", PricePerUnit = 1.8, MeasurementType = MeasurementType.Pieces,
                ImagePath = "static/Images/IngredientStatic/avocado.png"
            },
            new
            {
                Name = "Brokkoli", PricePerUnit = 0.0037, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/brokkoli.png"
            },
            new
            {
                Name = "Spinat", PricePerUnit = 0.0045, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/spinat.png"
            },
            new
            {
                Name = "Champignons", PricePerUnit = 0.0052, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/champignons.png"
            },
            new
            {
                Name = "Mais", PricePerUnit = 0.9, MeasurementType = MeasurementType.Pieces,
                ImagePath = "static/Images/IngredientStatic/mais.png"
            },
            new
            {
                Name = "Erbsen", PricePerUnit = 0.0024, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/erbsen.png"
            },
            new
            {
                Name = "Bohnen", PricePerUnit = 0.0026, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/bohnen.png"
            },
            new
            {
                Name = "Mandeln", PricePerUnit = 0.0140, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/mandeln.png"
            },
            new
            {
                Name = "Haselnüsse", PricePerUnit = 0.0165, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/haselnuesse.png"
            },
            new
            {
                Name = "Walnüsse", PricePerUnit = 0.0158, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/walnuesse.png"
            },
            new
            {
                Name = "Kokosmilch", PricePerUnit = 0.0034, MeasurementType = MeasurementType.Milliliter,
                ImagePath = "static/Images/IngredientStatic/kokosmilch.png"
            },
            new
            {
                Name = "Sojasauce", PricePerUnit = 0.0056, MeasurementType = MeasurementType.Milliliter,
                ImagePath = "static/Images/IngredientStatic/sojasauce.png"
            },
            new
            {
                Name = "Ketchup", PricePerUnit = 0.0031, MeasurementType = MeasurementType.Milliliter,
                ImagePath = "static/Images/IngredientStatic/ketchup.png"
            },
            new
            {
                Name = "Senf", PricePerUnit = 0.0027, MeasurementType = MeasurementType.Milliliter,
                ImagePath = "static/Images/IngredientStatic/senf.png"
            },
            new
            {
                Name = "Mayonnaise", PricePerUnit = 0.0040, MeasurementType = MeasurementType.Milliliter,
                ImagePath = "static/Images/IngredientStatic/mayonnaise.png"
            },
            new
            {
                Name = "Mineralwasser", PricePerUnit = 0.0008, MeasurementType = MeasurementType.Milliliter,
                ImagePath = "static/Images/IngredientStatic/mineralwasser.png"
            },
            new
            {
                Name = "Kaffeebohnen", PricePerUnit = 0.0180, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/kaffeebohnen.png"
            },
            new
            {
                Name = "Schokolade", PricePerUnit = 0.0075, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/schokolade.png"
            },
            new
            {
                Name = "Vanillebohnen", PricePerUnit = 0.2, MeasurementType = MeasurementType.Pieces,
                ImagePath = "static/Images/IngredientStatic/vanille.png"
            },
            new
            {
                Name = "Zimt", PricePerUnit = 0.0090, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/zimt.png"
            },
            new
            {
                Name = "Pfeffer", PricePerUnit = 0.0125, MeasurementType = MeasurementType.Gram,
                ImagePath = "static/Images/IngredientStatic/pfeffer.png"
            },
            new
            {
                Name = "Chili", PricePerUnit = 0.0108, MeasurementType = MeasurementType.Gram,
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
                $"Missing ingredient '{name}'. Ensure Ingredient seeding creates it with the exact same Name.");
        }

        var recipes = new[]
        {
            new
            {
                Name = "Spaghetti Aglio e Olio",
                Description = "Schnell, würzig, knoblauchig – perfektes Feierabendgericht.",
                Prep = 10,
                Cook = 12,
                Difficulty = CookingDifficulty.Easy,
                ImageFile = "/static/Images/RecipeStatic/spaghetti.png",
                CookingInstructions =
                    "Nudeln in reichlich gesalzenem Wasser al dente kochen. " +
                    "Währenddessen Knoblauch in dünne Scheiben schneiden. " +
                    "Olivenöl in einer großen Pfanne bei mittlerer Hitze erwärmen und den Knoblauch langsam goldgelb anbraten;" +
                    " nicht verbrennen lassen, sonst wird er bitter. " +
                    "Etwas Nudelwasser abschöpfen. Nudeln abgießen und direkt in die Pfanne geben. " +
                    "Mit 2–3 EL Nudelwasser vermengen, damit eine cremige Emulsion entsteht. " +
                    "Mit Salz und frisch gemahlenem Pfeffer abschmecken. " +
                    "Optional mit Chiliflocken verfeinern und sofort servieren.",
                Ingredients = new (string Name, decimal Amount)[]
                {
                    ("Nudeln", 200m),
                    ("Olivenöl", 30m),
                    ("Knoblauch", 8m),
                    ("Salz", 5m),
                    ("Pfeffer", 2m),
                }
            },
            new
            {
                Name = "Tomate-Basilikum-Pasta",
                Description = "Fruchtige Tomaten, Basilikum und Olivenöl – simpel & gut.",
                Prep = 10,
                Cook = 18,
                Difficulty = CookingDifficulty.Easy,
                ImageFile = "/static/Images/RecipeStatic/tomate-basilikum-pasta.png",
                CookingInstructions =
                    "Nudeln in Salzwasser al dente kochen. " +
                    "Tomaten würfeln, Knoblauch fein hacken. " +
                    "Olivenöl in einer Pfanne erhitzen, Knoblauch kurz anschwitzen. " +
                    "Tomaten zugeben und bei mittlerer Hitze 10–12 Minuten köcheln lassen, bis sie weich sind und eine sämige Sauce entsteht. " +
                    "Mit Salz abschmecken. Nudeln abgießen und direkt unter die Sauce mischen. " +
                    "Frisch gezupften Basilikum erst kurz vor dem Servieren unterheben, damit das Aroma erhalten bleibt. " +
                    "Mit etwas Olivenöl beträufeln und optional Parmesan darübergeben.",
                Ingredients = new (string Name, decimal Amount)[]
                {
                    ("Nudeln", 200m),
                    ("Tomaten", 300m),
                    ("Olivenöl", 20m),
                    ("Knoblauch", 6m),
                    ("Basilikum", 10m),
                    ("Salz", 5m),
                }
            },
            new
            {
                Name = "Pfannkuchen",
                Description = "Klassische Pfannkuchen – süß oder herzhaft möglich.",
                Prep = 10,
                Cook = 15,
                Difficulty = CookingDifficulty.Easy,
                ImageFile = "/static/Images/RecipeStatic/pfannkuchen.png",
                CookingInstructions =
                    "Mehl, Milch, Eier, Zucker und eine Prise Salz zu einem glatten Teig verrühren. " +
                    "5 Minuten ruhen lassen. Eine beschichtete Pfanne erhitzen und etwas Butter darin schmelzen. " +
                    "Eine Kelle Teig hineingeben und durch Schwenken gleichmäßig verteilen. " +
                    "Bei mittlerer Hitze 2–3 Minuten backen, bis die Unterseite goldbraun ist, dann wenden und fertig backen. " +
                    "Vorgang wiederholen, bis der Teig aufgebraucht ist. Warm servieren; süß mit Obst oder herzhaft gefüllt.",
                Ingredients = new (string Name, decimal Amount)[]
                {
                    ("Mehl", 200m),
                    ("Milch", 250m),
                    ("Eier", 2m),
                    ("Butter", 30m),
                    ("Zucker", 25m),
                    ("Salz", 2m),
                }
            },
            new
            {
                Name = "Rührei",
                Description = "Cremiges Rührei – ideal zum Frühstück.",
                Prep = 5,
                Cook = 7,
                Difficulty = CookingDifficulty.Easy,
                ImageFile = "/static/Images/RecipeStatic/ruehrei.png",
                CookingInstructions =
                    "Eier in eine Schüssel aufschlagen und mit Salz und Pfeffer verquirlen. " +
                    "Butter in einer beschichteten Pfanne bei niedriger bis mittlerer Hitze schmelzen lassen. " +
                    "Eiermasse hineingeben und kurz stocken lassen. " +
                    "Mit einem Pfannenwender langsam vom Rand zur Mitte schieben, sodass große, cremige Flocken entstehen. " +
                    "Nicht zu stark erhitzen, damit das Rührei saftig bleibt. " +
                    "Vom Herd ziehen, sobald es noch leicht glänzt – es gart in der Resthitze nach. Sofort servieren.",
                Ingredients = new (string Name, decimal Amount)[]
                {
                    ("Eier", 3m),
                    ("Butter", 15m),
                    ("Salz", 2m),
                    ("Pfeffer", 1m),
                }
            },
            new
            {
                Name = "Tomatensuppe",
                Description = "Samtige Suppe – mit Basilikum richtig rund.",
                Prep = 10,
                Cook = 20,
                Difficulty = CookingDifficulty.Easy,
                ImageFile = "/static/Images/RecipeStatic/tomatensuppe.png",
                CookingInstructions =
                    "Zwiebeln und Knoblauch fein hacken. Olivenöl in einem Topf erhitzen und beides glasig dünsten. " +
                    "Tomaten grob würfeln und zugeben. Mit Salz und Pfeffer würzen und 15–20 Minuten köcheln lassen. " +
                    "Anschließend die Suppe fein pürieren, bis sie samtig ist. " +
                    "Bei Bedarf etwas Wasser oder Brühe ergänzen. " +
                    "Frischen Basilikum kurz vor dem Servieren unterrühren oder darüberstreuen. " +
                    "Optional mit einem Schuss Sahne verfeinern.",
                Ingredients = new (string Name, decimal Amount)[]
                {
                    ("Tomaten", 500m),
                    ("Zwiebeln", 120m),
                    ("Knoblauch", 6m),
                    ("Olivenöl", 15m),
                    ("Salz", 6m),
                    ("Pfeffer", 2m),
                    ("Basilikum", 8m),
                }
            },
            new
            {
                Name = "Ofenkartoffeln",
                Description = "Knusprig aus dem Ofen – wenig Aufwand, viel Genuss.",
                Prep = 10,
                Cook = 35,
                Difficulty = CookingDifficulty.Easy,
                ImageFile = "/static/Images/RecipeStatic/ofenkartoffel.png",
                CookingInstructions =
                    "Backofen auf 200°C Ober-/Unterhitze vorheizen. " +
                    "Kartoffeln gründlich waschen und in Spalten oder Würfel schneiden. " +
                    "Mit Olivenöl, Salz und Pfeffer in einer Schüssel vermengen, sodass alles gleichmäßig bedeckt ist. " +
                    "Auf ein mit Backpapier belegtes Blech geben und nicht übereinanderlegen. " +
                    "30–35 Minuten backen, bis sie außen knusprig und innen weich sind. " +
                    "Zwischendurch einmal wenden. Heiß servieren, optional mit Kräutern oder Dip.",
                Ingredients = new (string Name, decimal Amount)[]
                {
                    ("Kartoffeln", 600m),
                    ("Olivenöl", 20m),
                    ("Salz", 6m),
                    ("Pfeffer", 2m),
                }
            },
            new
            {
                Name = "Zitronen-Hähnchen",
                Description = "Frisch, leicht und zitronig – passt zu Reis oder Salat.",
                Prep = 10,
                Cook = 20,
                Difficulty = CookingDifficulty.Medium,
                ImageFile = "/static/Images/RecipeStatic/zitronen-haehnchen.png",
                CookingInstructions =
                    "Hähnchenbrust trocken tupfen und mit Salz und Pfeffer würzen. " +
                    "Olivenöl in einer Pfanne erhitzen und das Fleisch bei mittlerer Hitze von beiden Seiten goldbraun anbraten. " +
                    "Knoblauch fein hacken und kurz mitbraten. Mit dem Saft einer Zitrone ablöschen und etwas Zitronenabrieb zugeben. " +
                    "Hitze reduzieren und das Hähnchen 8–10 Minuten gar ziehen lassen. " +
                    "Vor dem Servieren kurz ruhen lassen und in Scheiben schneiden.",
                Ingredients = new (string Name, decimal Amount)[]
                {
                    ("Hähnchenbrust", 300m),
                    ("Zitronen", 1m),
                    ("Olivenöl", 15m),
                    ("Knoblauch", 4m),
                    ("Salz", 5m),
                    ("Pfeffer", 2m),
                }
            },
            new
            {
                Name = "Caprese-Salat",
                Description = "Tomaten, Basilikum, Olivenöl – einfach & frisch.",
                Prep = 8,
                Cook = 0,
                Difficulty = CookingDifficulty.Easy,
                ImageFile = "/static/Images/RecipeStatic/caprese-salat.png",
                CookingInstructions =
                    "Tomaten in gleichmäßige Scheiben schneiden. Auf einem Teller leicht überlappend anrichten. " +
                    "Mit Salz und frisch gemahlenem Pfeffer würzen. Olivenöl gleichmäßig darüberträufeln. Basilikumblätter" +
                    " grob zupfen und über die Tomaten streuen. Kurz durchziehen lassen, damit sich die Aromen verbinden. " +
                    "Optional mit etwas Balsamico oder frischem Mozzarella ergänzen.",
                Ingredients = new (string Name, decimal Amount)[]
                {
                    ("Tomaten", 300m),
                    ("Basilikum", 10m),
                    ("Olivenöl", 15m),
                    ("Salz", 4m),
                    ("Pfeffer", 2m),
                }
            }
        };

        for (var index = 0; index < recipes.Length; index++)
        {
            var r = recipes[index];
            var ownerUserId = users[index % users.Count].Id;

            var imagePath = r.ImageFile;

            var existing = await db.Recipes
                .Include(x => x.RecipeIngredients)
                .Include(x => x.Images)
                .SingleOrDefaultAsync(x => x.Name == r.Name, ct);

            if (existing is null)
            {
                existing = new Recipe
                {
                    Name = r.Name,
                    Description = r.Description,
                    PreparationTime = r.Prep,
                    CookingTime = r.Cook,
                    CookingDifficulty = r.Difficulty,
                    UserId = ownerUserId,
                    CookingInstructions = r.CookingInstructions,
                    ImagePath = imagePath,

                    Images = new List<RecipeImage>(),
                    RecipeIngredients = new List<RecipeIngredient>(),
                };

                db.Recipes.Add(existing);
            }
            else
            {
                existing.Description = r.Description;
                existing.PreparationTime = r.Prep;
                existing.CookingTime = r.Cook;
                existing.CookingDifficulty = r.Difficulty;
                existing.UserId = ownerUserId;
                existing.ImagePath = imagePath;

                existing.RecipeIngredients ??= new List<RecipeIngredient>();
                existing.Images ??= new List<RecipeImage>();

                db.RecipeIngredients.RemoveRange(existing.RecipeIngredients);
                existing.RecipeIngredients.Clear();

                db.RecipeImages.RemoveRange(existing.Images);
                existing.Images.Clear();
            }

            existing.Images.Add(new RecipeImage
            {
                ImagePath = imagePath,
                IsPrimary = true
            });

            foreach (var (ingredientName, amount) in r.Ingredients)
            {
                Ingredient i = await db.Ingredients.SingleOrDefaultAsync(x => x.Name == ingredientName, ct);
                existing.RecipeIngredients.Add(new RecipeIngredient
                {
                    Recipe = existing,
                    RecipeId = existing.Id,
                    IngredientId = i.Id,
                    Ingredient = i,
                    Amount = amount
                });
            }
        }

        await db.SaveChangesAsync(ct);
    }
}