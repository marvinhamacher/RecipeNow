using System.ComponentModel.DataAnnotations;

namespace RecipeNow.Data.Entities.RecipeSystem;

public class ShelfIngredient
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Darf nicht leer sein")]
    public DateTime ExpirationDate { get; set; }
    
    
    [Required(ErrorMessage = "Darf nicht leer sein")]
    public required int ShelfId { get; set; }
    [Required(ErrorMessage = "Darf nicht leer sein")]
    public required Shelf Shelf { get; set; } = null!;

    [Required(ErrorMessage = "Darf nicht leer sein")]
    public required int IngredientId { get; set; }
    [Required(ErrorMessage = "Darf nicht leer sein")]
    public required Ingredient Ingredient { get; set; } = null!;
    
    
    [Required(ErrorMessage = "Darf nicht leer sein")]
    public int Amount { get; set; }
    
    [Required(ErrorMessage = "Darf nicht leer sein")]
    public int Row { get; set; }
    
    [Required(ErrorMessage = "Darf nicht leer sein")]
    public int Column { get; set; }
    
    
}