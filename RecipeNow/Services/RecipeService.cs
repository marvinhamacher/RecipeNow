using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RecipeNow.Config;
using RecipeNow.Data.Contexts;
using RecipeNow.Data.Entities.RecipeSystem;

namespace RecipeNow.Services;

public class RecipeService : IRecipeService
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _env;
    private readonly UploadSettings _uploadSettings;

    public RecipeService(AppDbContext context, IWebHostEnvironment env, IOptions<UploadSettings> uploadSettings)
    {
        _context = context;
        _env = env;
        _uploadSettings = uploadSettings.Value;
    }

    public async Task AddAsync(
        Recipe recipe,
        IEnumerable<IBrowserFile> images,
        IEnumerable<(int IngredientId, decimal Amount)> ingredients)
    {
        var uploadDir = Path.Combine(_env.WebRootPath, "images", "Recipes");
        Directory.CreateDirectory(uploadDir);

        var imageList = images?.ToList() ?? new List<IBrowserFile>();
        if (imageList.Count == 0)
            throw new InvalidOperationException("Es muss mindestens ein Bild hochgeladen werden.");

        // Rezept zuerst speichern, damit wir recipe.Id haben
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        var recipeImages = new List<RecipeImage>();

        for (var i = 0; i < imageList.Count; i++)
        {
            var image = imageList[i];

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.Name)}";
            var filePath = Path.Combine(uploadDir, fileName);

            await using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await image.OpenReadStream(_uploadSettings.MaxImageSize).CopyToAsync(fs);
            }

            var relativePath = $"/images/recipes/{fileName}";
            var isPrimary = i == 0;

            if (isPrimary)
                recipe.ImagePath = relativePath;

            recipeImages.Add(new RecipeImage
            {
                RecipeId = recipe.Id,
                Recipe = recipe,
                ImagePath = relativePath,
                IsPrimary = isPrimary
            });
        }

        _context.RecipeImages.AddRange(recipeImages);

        var rows = ingredients
            .Where(x => x.Amount > 0)
            .Select(x => new RecipeIngredient
            {
                Id = 0,
                RecipeId = recipe.Id,
                Recipe = recipe,
                IngredientId = x.IngredientId,
                Ingredient = null!,
                Amount = x.Amount
            })
            .ToList();

        _context.RecipeIngredients.AddRange(rows);

        await _context.SaveChangesAsync();
    }

    public Task<List<Recipe>> GetAllAsync()
    {
        return _context.Recipes.AsNoTracking()
            .OrderBy(i => i.Name)
            .ToListAsync();
    }

    public Task<Recipe?> GetByIdAsync(int id)
    {
        return _context.Recipes
            .AsNoTracking()
            .Include(r => r.Images)
            .Include(r => r.RecipeIngredients)
            .ThenInclude(ri => ri.Ingredient)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task DeleteAsync(int id)
    {   
        Recipe recipe = await _context.Recipes.FindAsync(id);
        if (recipe is null) throw new InvalidOperationException("Rezept nicht gefunden.");
        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(
        Recipe recipe,
        IEnumerable<IBrowserFile> newImages,
        IEnumerable<int> keptImageIds,
        IEnumerable<(int IngredientId, decimal Amount)> ingredients)
    {
        var entity = await _context.Recipes
            .Include(r => r.Images)
            .Include(r => r.RecipeIngredients)
            .FirstOrDefaultAsync(r => r.Id == recipe.Id);

        if (entity is null)
            throw new InvalidOperationException("Rezept nicht gefunden.");
        
        entity.Name = recipe.Name;
        entity.Description = recipe.Description;
        entity.PreparationTime = recipe.PreparationTime;
        entity.CookingTime = recipe.CookingTime;
        entity.CookingDifficulty = recipe.CookingDifficulty;

        
        var incomingIngredients = ingredients
            .Where(x => x.Amount > 0)
            .ToList();

        var incomingIds = incomingIngredients.Select(x => x.IngredientId).ToHashSet();

        var toRemoveIngredients = entity.RecipeIngredients
            .Where(ri => !incomingIds.Contains(ri.IngredientId))
            .ToList();

        _context.RecipeIngredients.RemoveRange(toRemoveIngredients);

        foreach (var (ingredientId, amount) in incomingIngredients)
        {
            var existing = entity.RecipeIngredients.FirstOrDefault(ri => ri.IngredientId == ingredientId);
            if (existing is null)
            {
                entity.RecipeIngredients.Add(new RecipeIngredient
                {
                    RecipeId = entity.Id,
                    Recipe = entity,
                    IngredientId = ingredientId,
                    Ingredient = null!,
                    Amount = amount
                });
            }
            else
            {
                existing.Amount = amount;
            }
        }

        // 3) Bilder entfernen, die nicht mehr gewünscht sind
        var keptSet = keptImageIds?.ToHashSet() ?? new HashSet<int>();

        var uploadDir = Path.Combine(_env.WebRootPath, "images", "Recipes");
        Directory.CreateDirectory(uploadDir);

        var toRemoveImages = entity.Images
            .Where(img => img.Id != 0 && !keptSet.Contains(img.Id))
            .ToList();

        foreach (var img in toRemoveImages)
        {
            // img.ImagePath z.B. "/images/recipes/xyz.jpg"
            var relative = img.ImagePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
            var physical = Path.Combine(_env.WebRootPath, relative);

            if (File.Exists(physical))
                File.Delete(physical);
        }

        _context.RecipeImages.RemoveRange(toRemoveImages);

        // 4) Neue Bilder hinzufügen (immer neue Dateien erzeugen)
        var newImageList = newImages?.ToList() ?? new List<IBrowserFile>();

        foreach (var image in newImageList)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.Name)}";
            var filePath = Path.Combine(uploadDir, fileName);

            await using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await image.OpenReadStream(_uploadSettings.MaxImageSize).CopyToAsync(fs);
            }

            var relativePath = $"/images/recipes/{fileName}";

            entity.Images.Add(new RecipeImage
            {
                RecipeId = entity.Id,
                Recipe = entity,
                ImagePath = relativePath,
                IsPrimary = false
            });
        }

        // 5) Primary/Preview ImagePath setzen (einfach: erstes Bild = primary)
        foreach (var img in entity.Images)
            img.IsPrimary = false;

        var primary = entity.Images.FirstOrDefault();
        if (primary is not null)
        {
            primary.IsPrimary = true;
            entity.ImagePath = primary.ImagePath;
        }
        else
        {
            entity.ImagePath = string.Empty;
        }

        await _context.SaveChangesAsync();
    }
    
    public async Task<List<Recipe>> SuggestRecipesAsync(string userId)
    {
        var stock = await BuildStockAsync(userId);
    
        var recipes = await _context.Recipes
            .Include(r => r.RecipeIngredients)
            .ThenInclude(ri => ri.Ingredient)
            .ToListAsync();
    
        return FindBestRecipes(stock, recipes);
    }

    public async Task<Dictionary<int, decimal>> BuildStockAsync(string userId)
    {
        var now = DateTime.UtcNow;
        
        var shelfIngredients = await _context.StorageRooms
            .Where(sr => sr.UserId == userId)
            .SelectMany(sr => sr.StorageRoomShelf)
            .SelectMany(s => s.ShelfIngredients)
            .Where(si => si.ExpirationDate > now)
            .ToListAsync();
    
        return shelfIngredients
            .GroupBy(x => x.IngredientId)
            .ToDictionary(
                g => g.Key,
                g => g.Sum(x => x.Amount)
            );
    }

    public List<Recipe> FindBestRecipes(Dictionary<int, decimal> pantry, List<Recipe> recipes)
    {
        Console.WriteLine("Pantry:" + pantry);
        int maxTolerance = recipes.Max(r => r.RecipeIngredients.Count);
        
        // Alle rezepte ausgeben die infrage kommen (zutaten da, nix abgelaufen)
        for (int tolerance = 0; tolerance <= maxTolerance; tolerance++)
        {
            var matches = new List<Recipe>();
        
            foreach (var recipe in recipes)
            {
                int missing = CountMissing(recipe, pantry);
                Console.WriteLine("missing: " + missing);
                Console.WriteLine("tolerance:" + tolerance);
        
                if (missing <= tolerance)
                    matches.Add(recipe);
            }
        
            if (matches.Any())
            {
                var ordered = matches
                    .OrderBy(r => CalculateRecipeCost(r))
                    .ToList();
        
                Console.WriteLine($"Treffer bei Toleranz {tolerance}");
                foreach (var r in ordered)
                    Console.WriteLine($"{r.Name} | Cost={CalculateRecipeCost(r)}");
        
                return ordered;
            }
        }
        
        // das günstigste aus den gefundenen ausgeben
        // for (int tolerance = 0; tolerance <= maxTolerance; tolerance++)
        // {
        //     var best = recipes
        //         .Where(r => CountMissing(r, pantry) <= tolerance)
        //         .OrderBy(r => CalculateRecipeCost(r))
        //         .FirstOrDefault();
        //
        //     if (best != null)
        //     {
        //         Console.WriteLine($"Gewähltes Rezept: {best.Name}");
        //         Console.WriteLine($"Kosten: {CalculateRecipeCost(best)}");
        //         Console.WriteLine($"Tolerance: {tolerance}");
        //         return new List<Recipe> { best }; // hab jetzt so gelassen weil hab bei alle rezepte ausgeben auch liste gegeben...
        //     }
        // }
    
        return new List<Recipe>();
    }
    
    public int CountMissing(Recipe recipe, Dictionary<int, decimal> pantry)
    {
        int missing = 0;
    
        foreach (var req in recipe.RecipeIngredients)
        {
            if (!pantry.TryGetValue(req.IngredientId, out var available)
                || available < req.Amount)
            {
                missing++;
            }
        }
    
        return missing;
    }
    
    private decimal CalculateRecipeCost(Recipe recipe)
    {
        decimal total = 0;

        foreach (var ri in recipe.RecipeIngredients)
        {
            if (ri.Ingredient == null)
            {
                continue;
            }
            
            total += ri.Amount * Convert.ToDecimal(ri.Ingredient.PricePerUnit);
        }

        return total;
    }
}