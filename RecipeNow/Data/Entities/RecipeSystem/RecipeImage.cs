using System.ComponentModel.DataAnnotations;

namespace RecipeNow.Data.Entities.RecipeSystem;

public class RecipeImage
{
    public int Id { get; set; }

    [Required]
    public int RecipeId { get; set; }

    [Required]
    public Recipe Recipe { get; set; } = null!;

    [Required]
    [MaxLength(255)]
    public string ImagePath { get; set; } = string.Empty;

    public bool IsPrimary { get; set; }
}