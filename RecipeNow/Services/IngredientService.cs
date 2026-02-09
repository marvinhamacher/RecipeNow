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

    public async Task UpdateAsync(Ingredient ingredient, IBrowserFile? img)
    {
        var entity = await _context.Ingredients.FirstOrDefaultAsync(x => x.Id == ingredient.Id);
        if (entity is null)
            return;

        entity.Name = ingredient.Name;
        entity.PricePerUnit = ingredient.PricePerUnit;
        entity.Measurement = ingredient.Measurement;

        var oldImagePath = entity.ImagePath;

        if (img is not null)
        {
            var uploadDir = Path.Combine(_env.WebRootPath, "images", "ingredients");
            Directory.CreateDirectory(uploadDir);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(img.Name)}";
            var filePath = Path.Combine(uploadDir, fileName);

            await using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await img.OpenReadStream(_uploadSettings.MaxImageSize).CopyToAsync(fs);
            }

            entity.ImagePath = $"/images/ingredients/{fileName}";

            if (!string.IsNullOrWhiteSpace(oldImagePath))
            {
                TryDeleteIngredientImage(oldImagePath);
            }
        }
        else
        {
            entity.ImagePath = ingredient.ImagePath;
        }

        await _context.SaveChangesAsync();
    }

    private void TryDeleteIngredientImage(string webPath)
    {
        var relative = webPath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
        var fullPath = Path.Combine(_env.WebRootPath, relative);

        if (!File.Exists(fullPath))
            return;

        try
        {
            File.Delete(fullPath);
        }
        catch
        {
            Console.WriteLine("Löschen Fehlgeschlagen.");
        }
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

    public async Task<List<Ingredient>> GetAllAsync()
    {
       return await _context.Ingredients
            .AsNoTracking()
            .OrderBy(i => i.Name)
            .ToListAsync();
    
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