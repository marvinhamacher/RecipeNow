using System.ComponentModel.DataAnnotations;
using RecipeNow.Data.Enumerators;

namespace RecipeNow.Data.Entities.RecipeSystem;

public class Shelf
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string ContentDescription { get; set; }
    
    [Required]
    public int Height { get; set; }
    
    [Required]
    public int Width{ get; set; }
    
    
    [Required]
    public int StorageRoomId { get; set; }
    
    [Required]
    public ICollection<ShelfIngredient> ShelfIngredients{ get; set; }
        = new List<ShelfIngredient>();
    
    
}