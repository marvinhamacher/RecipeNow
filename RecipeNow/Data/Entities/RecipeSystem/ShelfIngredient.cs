using System.ComponentModel.DataAnnotations;

namespace RecipeNow.Data.Entities.RecipeSystem;

public class ShelfIngredient
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Darf nicht leer sein")]
    public DateTime ExpirationDate { get; set; }
    
    [Required]
    public int ShelfId { get; set; }

    [Required]
    public int IngredientId { get; set; }
    
    public Shelf? Shelf { get; set; }

    public Ingredient? Ingredient { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    public int Row { get; set; }

    [Required]
    public int Column { get; set; }
}
