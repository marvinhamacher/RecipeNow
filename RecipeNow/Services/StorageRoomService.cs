using Microsoft.EntityFrameworkCore;
using RecipeNow.Data.Contexts;
using RecipeNow.Data.Entities.RecipeSystem;

namespace RecipeNow.Services;

public class StorageRoomService
{
    private readonly AppDbContext _context;


    public StorageRoomService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddShelfAsync(int storageRoomId, String shelfName, int height, int width)
    {
        ;
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

    public Task SwapIngredientPositionsWithAnotherAsync(int shelfIngredient1Id, int shelfIngredient2Id)
    {
        //_dbcontext.ShelfIngredients.Find(shelfIngredient1Id) 
        //_dbcontext.ShelfIngredients.Find(shelfIngredient2Id) 
        throw new NotImplementedException();
    }

    public Task ChangeIngredientPosition(ShelfIngredient ingredient, int newColumn, int newRow)
    {
        //TODO;
        // hole aus ShelfIngredient den Shelf und schau ob auf positon newColumn und newRow bereits ein Ingredient steht
        // wenn ja > swap
        // wenn nein > einfach platzieren
        throw new NotImplementedException();
    }
}