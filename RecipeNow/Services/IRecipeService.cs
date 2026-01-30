using Microsoft.AspNetCore.Components.Forms;
using RecipeNow.Data.Entities.RecipeSystem;

namespace RecipeNow.Services;

public interface IRecipeService
{
    Task AddAsync(Recipe recipe,IEnumerable<IBrowserFile> image, IEnumerable<(int IngredientId, decimal Amount)> ingredients);
    Task<List<Recipe>> GetAllAsync();
    Task<Recipe?> GetByIdAsync(int id);
}