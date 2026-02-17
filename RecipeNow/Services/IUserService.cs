using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace RecipeNow.Services;

public interface IUserService
{
    Task<ClaimsPrincipal> GetUserAsync();

    Task<string?> GetUserNameAsync();

    Task<bool> IsAuthenticated();

    Task<bool> IsAdmin();

    Task LogoutAsync();

    Task<IdentityUser?> GetUserByIdAsync(string userId);
}