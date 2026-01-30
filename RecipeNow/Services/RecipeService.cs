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
}