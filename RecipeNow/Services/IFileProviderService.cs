namespace RecipeNow.Services;

public interface IFileProviderService
{ 
    Task<byte[]> CreateRecipeTxtBlob(int id);
    Task<Stream> CreateRecipePdfStream(int id);
}