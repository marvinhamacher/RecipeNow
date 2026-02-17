using System.ComponentModel.DataAnnotations;

namespace RecipeNow.Data.Entities.RecipeSystem;

public class RecipeImage
{
    public int Id { get; set; }

    [Required (ErrorMessage = "Darf nicht leer sein")]
    public int RecipeId { get; set; }

    [Required (ErrorMessage = "Darf nicht leer sein")]
    public Recipe Recipe { get; set; } = null!;

    [Required (ErrorMessage = "Darf nicht leer sein")]
    [MaxLength(255, ErrorMessage = "Auf 255 Charaktere begrenzt")]
    public string ImagePath { get; set; } = string.Empty;

    public bool IsPrimary { get; set; }
}