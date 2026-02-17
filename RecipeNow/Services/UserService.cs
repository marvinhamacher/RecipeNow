using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace RecipeNow.Services;

using RecipeNow.Data.Contexts;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

public class UserService : IUserService
{
    private readonly AuthDbContext _dbContext;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly NavigationManager _navigationManager;
    public UserService(
        AuthDbContext dbContext, 
        AuthenticationStateProvider authStateProvider,
        SignInManager<IdentityUser> signInManager,
        NavigationManager navigationManager)
    {
        _dbContext = dbContext;
        _authStateProvider = authStateProvider;
        _signInManager = signInManager;
        _navigationManager = navigationManager;
    }

    public async Task<ClaimsPrincipal> GetUserAsync()
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        return authState.User;
    }
    
    public async Task<string?> GetUserNameAsync()
    {
        var user = await GetUserAsync();
        return user.Identity?.Name;
    }

    public async Task<bool> IsAuthenticated()
    {
        var user = await GetUserAsync();
        return user.Identity?.IsAuthenticated == true;
    }

    public async Task<bool> IsAdmin()
    {
        var user = await GetUserAsync();
        return user.IsInRole("Admin");
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
        _navigationManager.NavigateTo("/",forceLoad:true);
    }

    public async Task<IdentityUser?> GetUserByIdAsync(string userId)
    {
        return await _dbContext.Users.FindAsync(userId);
    }
}