using System.ComponentModel.DataAnnotations;
using RecipeNow.Data.Enumerators;
namespace RecipeNow.Data.Entities.RecipeSystem;

public class Recipe
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name ist erforderlich")]
    [MaxLength(100, ErrorMessage = "Maximal 100 Zeichen")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Beschreibung ist erforderlich")]
    [MaxLength(1000, ErrorMessage = "Maximal 1000 Zeichen")]
    public string Description { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Muss größer als 0 sein")]
    public int PreparationTime { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Muss größer als 0 sein")]
    public int CookingTime { get; set; }

    public CookingDifficulty CookingDifficulty { get; set; } = CookingDifficulty.Medium;

    public string UserId { get; set; } = string.Empty;

    [MaxLength(255)]
    public string ImagePath { get; set; } = string.Empty;

    public ICollection<RecipeImage> Images { get; set; } = new List<RecipeImage>();

    public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        = new List<RecipeIngredient>();
}

