using Microsoft.AspNetCore.Components.Forms;
using RecipeNow.Data.Entities.RecipeSystem;

namespace RecipeNow.Services;

public interface IRecipeService
{
    Task AddAsync(Recipe recipe,IEnumerable<IBrowserFile> image, IEnumerable<(int IngredientId, decimal Amount)> ingredients);
    Task<List<Recipe>> GetAllAsync();
    Task<Recipe?> GetByIdAsync(int id);
    Task UpdateAsync(Recipe recipe, IEnumerable<IBrowserFile> newImages, IEnumerable<int> keptImageIds, IEnumerable<(int IngredientId, decimal Amount)> ingredients);
    Task DeleteAsync(int id);

    Task<List<Recipe>> SuggestRecipesAsync(string userId);

    Task<Dictionary<int, decimal>> BuildPantryAsync(string userId);

    List<Recipe> FindBestRecipes(Dictionary<int, decimal> pantry, List<Recipe> recipes);

    int CountMissing(Recipe recipe, Dictionary<int, decimal> pantry);
}