using System.ComponentModel.DataAnnotations;
using RecipeNow.Data.Enumerators;
namespace RecipeNow.Data.Entities.RecipeSystem;

public class Recipe
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Darf nicht leer sein")]
    [MaxLength(100, ErrorMessage = "Auf 100 Zeichen begrenzt")]
    public required string Name { get; set; }
    
    [MaxLength(1000, ErrorMessage = "Auf 1000 Zeichen begrenzt")]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "Darf nicht leer sein")]
    [MaxLength(1000, ErrorMessage = "Auf 1000 Zeichen begrenzt")]
    public required string CookingInstructions { get; set; }
    
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Darf nicht kleiner als 0 sein")]
    public required int PreparationTime { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    public required int CookingTime { get; set; }

    [Required (ErrorMessage = "Darf nicht leer sein")]
    public required CookingDifficulty CookingDifficulty { get; set; } = CookingDifficulty.Medium; // oder Enum später

    [Required (ErrorMessage = "Darf nicht leer sein")]
    public required string UserId { get; set; } 
    
    [MaxLength(255)]
    public string ImagePath { get; set; } = string.Empty;

    public ICollection<RecipeImage> Images { get; set; } = new List<RecipeImage>();

    public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        = new List<RecipeIngredient>();
}

