using System.ComponentModel.DataAnnotations;

namespace RecipeNow.Data.Entities.RecipeSystem;

public class RecipeIngredient
{
    public int Id { get; set; }
    
    [Required (ErrorMessage = "Darf nicht leer sein")]
    public required int RecipeId { get; set; }
    [Required (ErrorMessage = "Darf nicht leer sein")]
    public required Recipe Recipe { get; set; } = null!;

    [Required (ErrorMessage = "Darf nicht leer sein")]
    public required int IngredientId { get; set; }
    [Required (ErrorMessage = "Darf nicht leer sein")]
    public required Ingredient Ingredient { get; set; } = null!;

    // Menge der Zutat im Rezept
    [Range(0.0001, double.MaxValue, ErrorMessage = "Darf nicht kleiner als 0,0001 sein")]
    public decimal Amount { get; set; }
}