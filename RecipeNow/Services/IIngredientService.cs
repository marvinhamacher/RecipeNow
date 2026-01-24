using RecipeNow.Data.Entities.RecipeSystem;
namespace RecipeNow.Services;
using Microsoft.AspNetCore.Components.Forms;

public interface IIngredientService
{
    Task AddAsync(Ingredient ingredient, IBrowserFile image);
    Task<List<Ingredient>> GetAllAsync();
}
