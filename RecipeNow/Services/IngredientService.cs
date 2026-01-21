using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RecipeNow.Data.Contexts;
using RecipeNow.Data.Entities.RecipeSystem;
using RecipeNow.Config;

namespace RecipeNow.Services;

public class IngredientService : IIngredientService
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _env;
    private readonly UploadSettings _uploadSettings;

    public IngredientService(AppDbContext context, IWebHostEnvironment env, IOptions<UploadSettings> uploadSettings)
    {
        _context = context;
        _env = env;
        _uploadSettings = uploadSettings.Value;
    }
    
    public async Task<IEnumerable<Ingredient>> LoadAllAsync()
    {
        return await _context.Ingredients
            .AsNoTracking()
            .OrderBy(i => i.Name)
            .ToListAsync();
    }

    public async Task UpdateAsync(Ingredient ingredient)
    {
        // Minimal-Variante: alles updaten
        _context.Ingredients.Update(ingredient);
        await _context.SaveChangesAsync();

        // Alternative (sauberer): entity laden + Felder setzen + SaveChanges
        // var entity = await _db.Ingredients.FirstAsync(x => x.Id == ingredient.Id);
        // entity.Name = ingredient.Name;
        // entity.PricePerUnit = ingredient.PricePerUnit;
        // entity.Measurement = ingredient.Measurement;
        // entity.ImagePath = ingredient.ImagePath;
        // await _db.SaveChangesAsync();
    }

    public async Task AddAsync(Ingredient ingredient, IBrowserFile image)
    {
        Console.WriteLine("hallo");
        var uploadDir = Path.Combine(_env.WebRootPath, "images", "ingredients");
        Directory.CreateDirectory(uploadDir);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.Name)}";
        var filePath = Path.Combine(uploadDir, fileName);

        await using var fs = new FileStream(filePath, FileMode.Create);
        await image.OpenReadStream(_uploadSettings.MaxImageSize).CopyToAsync(fs);

        ingredient.ImagePath = $"/images/ingredients/{fileName}";

        _context.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Ingredients
            .FirstOrDefaultAsync(i => i.Id == id);

        if (entity == null)
            return;

        _context.Ingredients.Remove(entity);
        await _context.SaveChangesAsync();
    }
}