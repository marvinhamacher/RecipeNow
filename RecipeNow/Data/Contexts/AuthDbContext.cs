using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RecipeNow.Data.Contexts;

public class AuthDbContext : IdentityDbContext<IdentityUser>

{
    
}