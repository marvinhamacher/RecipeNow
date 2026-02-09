using System.ComponentModel.DataAnnotations;

namespace RecipeNow.Data.Entities.RecipeSystem;

public class StorageRoom
{
    public int Id { get; set; }
    
    [Required]
    public required string UserId { get; set; } 
    
    [Required]
    public ICollection<Shelf> StorageRoomShelf { get; set; }
        = new List<Shelf>();
}