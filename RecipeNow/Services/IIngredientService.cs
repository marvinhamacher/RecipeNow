using RecipeNow.Data.Entities.RecipeSystem;
namespace RecipeNow.Services;
using Microsoft.AspNetCore.Components.Forms;

public interface IIngredientService
{
    Task<IEnumerable<Ingredient>> LoadAllAsync();
    Task UpdateAsync(Ingredient ingredient, IBrowserFile? img);
    Task AddAsync(Ingredient ingredient, IBrowserFile image);
    Task<List<Ingredient>> GetAllAsync();
    Task DeleteAsync(int id);
}
