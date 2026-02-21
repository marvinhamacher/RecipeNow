using RecipeNow.Data.Entities.RecipeSystem;

namespace RecipeNow.Services;

public interface IStorageRoomService
{
    public Task AddShelfAsync(int storageRoomId, String contentDescription, int height, int width);

    public Task DeleteShelfAsync(int shelfId, int storageRoomId);

    public Task UpdateShelfContentDescriptionAsync(String newContentDescription, int id);

    public Task<List<Shelf>> GetStorageRoomShelfAsync(int storageRoomId);

    public Task AddIngredientToShelfAsync(ShelfIngredient entity);

    public Task AddStorageRoomAsync(string name);

    public Task SwapIngredientPositionsWithAnotherAsync(int shelfIngredient1Id, int shelfIngredient2Id);

    public Task ChangeIngredientPosition(ShelfIngredient ingredient, int newColumn, int newRow);

    public Task<StorageRoom?> GetStorageRoomByIdAsync(int id);

    public Task<ShelfIngredient?> GetShelfIngredientByPositionAsync(int shelfId, int column, int row);

    public Task<List<StorageRoom>> GetAllStorageRoomsByCurrentUserAsync();

    public Task DeleteStorageRoomAsync(int id);

    public Task UpdateStorageRoomAsync(StorageRoom storageRoom);

    public Task UpdateShelfIngredientPositionAsync(int sourceShelfIngredientId, int targetColumn, int targetRow,
        int targetShelfId);
    
    
}