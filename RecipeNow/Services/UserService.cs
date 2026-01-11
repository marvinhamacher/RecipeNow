namespace RecipeNow.Services;
using RecipeNow.Data.Contexts;

public class UserService
{
    private readonly AuthDbContext _dbContext;
    public UserService(AuthDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
}