using Microsoft.AspNetCore.Components.Forms;
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
        IBrowserFile image,
        IEnumerable<(int IngredientId, decimal Amount)> ingredients)
    {
        // 1) Bild speichern
        var uploadDir = Path.Combine(_env.WebRootPath, "images", "recipes");
        Directory.CreateDirectory(uploadDir);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.Name)}";
        var filePath = Path.Combine(uploadDir, fileName);

        await using (var fs = new FileStream(filePath, FileMode.Create))
        {
            await image.OpenReadStream(_uploadSettings.MaxImageSize).CopyToAsync(fs);
        }

        recipe.ImagePath = $"/images/recipes/{fileName}";

        // 2) Recipe speichern
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        // 3) Join-Tabelle speichern
        var rows = ingredients
            .Where(x => x.Amount > 0)
            .Select(x => new RecipeIngredient
            {
                Id = 0,
                RecipeId = recipe.Id,
                Recipe = recipe,
                IngredientId = x.IngredientId,
                Ingredient = null!, // FK reicht, Navigation wird nicht geladen
                Amount = x.Amount
            })
            .ToList();

        _context.RecipeIngredients.AddRange(rows);
        await _context.SaveChangesAsync();
    }
}