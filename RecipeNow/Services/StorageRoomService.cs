using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RecipeNow.Data.Contexts;
using RecipeNow.Data.Entities.RecipeSystem;

namespace RecipeNow.Services;

public class StorageRoomService
{
    private readonly AppDbContext _context;
    private readonly UserService _userService;
    public StorageRoomService(AppDbContext context, UserService userService)
    {
        _context = context;
        _userService = userService;
    }

    public async Task AddShelfAsync(int storageRoomId, String shelfName, int height, int width)
    {
        StorageRoom storageRoom = await _context.StorageRooms.FindAsync(storageRoomId);
        storageRoom?.StorageRoomShelf.Add(
            new Shelf
            {
                ContentDescription = shelfName,
                Height = height,
                Width = width,
                StorageRoomId = storageRoomId
            }
        );
        await _context.SaveChangesAsync();
    }

    public async Task DeleteShelfAsync(int shelfId, int storageRoomId)
    {
        StorageRoom storageRoom = await _context.StorageRooms.FindAsync(storageRoomId);
        storageRoom?.StorageRoomShelf.Remove(storageRoom.StorageRoomShelf.FirstOrDefault(s => s.Id == shelfId));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateShelfNameAsync(String newName, int id)
    {
        Shelf shelf = await _context.Shelves.FindAsync(id);
        shelf?.ContentDescription = newName;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Shelf>> GetStorageRoomShelfAsync(int storageRoomId)
    {
        var storageRoom = await _context.StorageRooms
            .Include(sr => sr.StorageRoomShelf)
            .FirstOrDefaultAsync(sr => sr.Id == storageRoomId);

        return storageRoom?.StorageRoomShelf?.ToList() ?? new List<Shelf>();
    }


    public async Task AddIngredientToShelfAsync(ShelfIngredient shelfIngredient)
    {
        _context.ShelfIngredients.Add(shelfIngredient);
        await _context.SaveChangesAsync();
    }

    public async Task AddStorageRoomAsync(StorageRoom storageRoom)
    {
        var user = await _userService.GetUserAsync();
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        storageRoom.UserId = userId;
        _context.StorageRooms.Add(storageRoom);
        await _context.SaveChangesAsync();
    }

    public Task SwapIngredientPositionsWithAnotherAsync(int shelfIngredient1Id, int shelfIngredient2Id)
    {
        //_dbcontext.ShelfIngredients.Find(shelfIngredient1Id) 
        //_dbcontext.ShelfIngredients.Find(shelfIngredient2Id) 
        throw new NotImplementedException();
    }

    public Task ChangeIngredientPosition(ShelfIngredient ingredient, int newColumn, int newRow)
    {
        // if(GetShelfIngredientByPositionAsync(ingredient.ShelfId, newColumn, newRow) != null) SwapIngredientPositionsWithAnotherAsync(ingredient.Id, GetShelfIngredientByPositionAsync(ingredient.ShelfId, newColumn, newRow).Id);
        //TODO;
        // hole aus ShelfIngredient den Shelf und schau ob auf positon newColumn und newRow bereits ein Ingredient steht
        // wenn ja > swap
        // wenn nein > einfach platzieren
        throw new NotImplementedException();
    }
    
    public async Task<StorageRoom?> GetStorageRoomByIdAsync(int id)
    {
        return await _context.StorageRooms.FindAsync(id);
    }

    public async Task<ShelfIngredient?> GetShelfIngredientByPositionAsync(int shelfId, int column, int row)
    {
        return await _context.ShelfIngredients.FirstOrDefaultAsync(si => si.ShelfId == shelfId && si.Column == column && si.Row == row);
    }

    public async Task<List<StorageRoom>> GetAllStorageRoomsByCurrentUserAsync()
    {
        var user = await _userService.GetUserAsync();
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        return await _context.StorageRooms
            .Where(sr => sr.UserId == userId  )
            .ToListAsync();
    }
}