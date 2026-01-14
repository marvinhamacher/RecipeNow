using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LogoutModel : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly NavigationManager _navigationManager;

    public LogoutModel(SignInManager<IdentityUser> signInManager, NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
        _signInManager = signInManager;
    }

    public async Task<bool> OnPostAsync()
    {
        await _signInManager.SignOutAsync();
        _navigationManager.NavigateTo("/", true);
        return true;
    }

    // Falls jemand die URL direkt im Browser aufruft (GET statt POST)
    public async Task<bool> OnGetAsync()
    {
        await _signInManager.SignOutAsync();
        _navigationManager.NavigateTo("/", true);
        return true;
    }
}