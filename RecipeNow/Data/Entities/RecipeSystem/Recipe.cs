using System.ComponentModel.DataAnnotations;
using RecipeNow.Data.Enumerators;
namespace RecipeNow.Data.Entities.RecipeSystem;

public class Recipe
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    
    [MaxLength(1000)]
    public string? Description { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    public required int PreparationTime { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    public required int CookingTime { get; set; }

    [Required] public required CookingDifficulty CookingDifficulty { get; set; } = CookingDifficulty.Medium; 

    [Required]
    public required string UserId { get; set; } 
    
    [MaxLength(255)]
    public string ImagePath { get; set; }
    
    public ICollection<RecipeImage> Images { get; set; }
    
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        = new List<RecipeIngredient>();
}
