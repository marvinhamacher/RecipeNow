using System.ComponentModel.DataAnnotations;

namespace RecipeNow.Data.Entities.RecipeSystem;

public class ShelfIngredient
{
    public int Id { get; set; }
    
    [Required]
    public DateTime ExpirationDate { get; set; }
    
    
    [Required]
    public required int ShelfId { get; set; }
    [Required]
    public required Shelf Shelf { get; set; } = null!;

    [Required]
    public required int IngredientId { get; set; }
    [Required]
    public required Ingredient Ingredient { get; set; } = null!;
    
    
    [Required]
    public int Amount { get; set; }
    
    [Required]
    public int Row { get; set; }
    
    [Required]
    public int Column { get; set; }
    
    
}