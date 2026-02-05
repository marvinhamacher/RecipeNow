using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeNow.Services;

public class DeleteRecipe : PageModel
{
    private readonly IRecipeService _recipeService;
    private readonly NavigationManager _navigationManager;
    
    public async Task<bool> OnDeleteAsync(int id)
    {
        _recipeService.DeleteAsync(id);
        _navigationManager.NavigateTo("/recipes/", true);
        return true;
    }
    
    public async Task<bool> OnGetAsync(int id)
    {
        _navigationManager.NavigateTo($"/recipes/{id}", true);
        return true;
    }
}