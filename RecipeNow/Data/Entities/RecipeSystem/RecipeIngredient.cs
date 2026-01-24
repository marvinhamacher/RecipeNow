using System.ComponentModel.DataAnnotations;

namespace RecipeNow.Data.Entities.RecipeSystem;

public class RecipeIngredient
{
    public int Id { get; set; }
    
    [Required]
    public required int RecipeId { get; set; }
    [Required]
    public required Recipe Recipe { get; set; } = null!;

    [Required]
    public required int IngredientId { get; set; }
    [Required]
    public required Ingredient Ingredient { get; set; } = null!;

    // Menge der Zutat im Rezept
    [Range(0.0001, double.MaxValue)]
    public decimal Amount { get; set; }
}