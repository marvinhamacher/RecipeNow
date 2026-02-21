using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using RecipeNow.Data.Contexts;
using RecipeNow.Data.Entities.RecipeSystem;

namespace RecipeNow.Services;

public class StorageRoomService: IStorageRoomService
{
    [Inject] private ILogger<StorageRoom> Logger { get; set; } = default!;
    private readonly AppDbContext _context;
    private readonly UserService _userService;
    public StorageRoomService(AppDbContext context, UserService userService)
    {
        _context = context;
        _userService = userService;
    }

    public async Task AddShelfAsync(int storageRoomId, String contentDescription, int height, int width)
    {
        StorageRoom storageRoom = await _context.StorageRooms.FindAsync(storageRoomId);
        storageRoom?.StorageRoomShelf.Add(
            new Shelf
            {
                ContentDescription = contentDescription,
                Height = height,
                Width = width,
                StorageRoomId = storageRoomId
            }
        );
        await _context.SaveChangesAsync();
    }

    public async Task DeleteShelfAsync(int shelfId, int storageRoomId)
    { 
        var storageRoom = await _context.StorageRooms
            .Include(sr => sr.StorageRoomShelf) 
            .FirstOrDefaultAsync(sr => sr.Id == storageRoomId);
        Shelf shelf = storageRoom.StorageRoomShelf.FirstOrDefault(s => s.Id == shelfId);
        storageRoom?.StorageRoomShelf.Remove(shelf);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateShelfContentDescriptionAsync(String newContentDescription, int id)
    {
        Shelf shelf = await _context.Shelves.FindAsync(id);
        shelf?.ContentDescription = newContentDescription;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Shelf>> GetStorageRoomShelfAsync(int storageRoomId)
    {
        var storageRoom = await _context.StorageRooms
            .Include(sr => sr.StorageRoomShelf) // load shelves
            .ThenInclude(s => s.ShelfIngredients)           // load ShelfIngredients
            .ThenInclude(si => si.Ingredient)                    // load Ingredients
            .FirstOrDefaultAsync(sr => sr.Id == storageRoomId);

        return storageRoom?.StorageRoomShelf?.ToList() ?? new List<Shelf>();
    }
    
    public async Task AddIngredientToShelfAsync(ShelfIngredient entity)
    {
        var exists = await _context.ShelfIngredients
            .AnyAsync(x =>
                x.ShelfId == entity.ShelfId &&
                x.Row == entity.Row &&
                x.Column == entity.Column);

        if (exists)
            throw new InvalidOperationException("Slot belegt");

        _context.ShelfIngredients.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddStorageRoomAsync(string name)
    {
        var user = await _userService.GetUserAsync();
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        StorageRoom storageRoom = new StorageRoom()
        {
            UserId = userId!,
            Name =  name,
            StorageRoomShelf =  new List<Shelf>()
        };
        _context.StorageRooms.Add(storageRoom);
        await _context.SaveChangesAsync();
    }

    public async Task SwapIngredientPositionsWithAnotherAsync(int shelfIngredient1Id, int shelfIngredient2Id)
    {
        var a = await _context.ShelfIngredients.FindAsync(shelfIngredient1Id);
        var b = await _context.ShelfIngredients.FindAsync(shelfIngredient2Id);

        if (a == null || b == null) return;

        (a.Row, b.Row) = (b.Row, a.Row);
        (a.Column, b.Column) = (b.Column, a.Column);
        (a.ShelfId, b.ShelfId) = (b.ShelfId, a.ShelfId);

        await _context.SaveChangesAsync();
    }

    public async Task ChangeIngredientPosition(ShelfIngredient ingredient, int newColumn, int newRow)
    {
        var other = await GetShelfIngredientByPositionAsync(
            ingredient.ShelfId,
            newColumn,
            newRow);

        if (other != null)
        {
            await SwapIngredientPositionsWithAnotherAsync(
                ingredient.Id,
                other.Id);
            return;
        }

        ingredient.Column = newColumn;
        ingredient.Row = newRow;

        _context.ShelfIngredients.Update(ingredient);
        await _context.SaveChangesAsync();
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
        Console.WriteLine(user);
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        Console.WriteLine(userId);
        return await _context.StorageRooms
            .Where(sr => sr.UserId == userId  )
            .ToListAsync();
    }
    
    
    public async Task DeleteStorageRoomAsync(int id)
    {
        StorageRoom storageRoom = await _context.StorageRooms.FindAsync(id);
        var user = await _userService.GetUserAsync();
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        if (storageRoom is null) throw new InvalidOperationException("Vorratsraum nicht gefunden.");
        if(storageRoom.UserId != userId) throw  new InvalidOperationException("Nur der Ersteller kann sein Vorratsraum löschen.");
        _context.StorageRooms.Remove(storageRoom);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateStorageRoomAsync(StorageRoom storageRoom)
    {
        var user = await _userService.GetUserAsync();
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        if(storageRoom.UserId != userId) throw  new InvalidOperationException("Nur der Ersteller kann sein Vorratsraum bearbeiten.");
        StorageRoom entity = await _context.StorageRooms.FindAsync(storageRoom.Id);
        if (entity is null) throw new InvalidOperationException("Vorratsraum nicht gefunden.");
        entity.Name = storageRoom.Name;
        await _context.SaveChangesAsync();
    }


    public async Task UpdateShelfIngredientPositionAsync(int sourceShelfIngredientId, int targetColumn, int targetRow, int targetShelfId)
    {
        var ingredient = await _context.ShelfIngredients.FindAsync(sourceShelfIngredientId);
        if (ingredient == null) return;

        var other = await GetShelfIngredientByPositionAsync(
            targetShelfId,
            targetColumn,
            targetRow);

        if (other != null)
        {
            await SwapIngredientPositionsWithAnotherAsync(
                ingredient.Id,
                other.Id);
            return;
        }

        ingredient.Column = targetColumn;
        ingredient.Row = targetRow;
        ingredient.ShelfId = targetShelfId;

        _context.ShelfIngredients.Update(ingredient);
        await _context.SaveChangesAsync();
    }
}