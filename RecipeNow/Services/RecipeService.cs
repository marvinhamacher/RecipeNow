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
}