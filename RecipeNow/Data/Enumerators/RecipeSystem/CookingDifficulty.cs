using System.ComponentModel.DataAnnotations;
namespace RecipeNow.Data.Enumerators;

public enum CookingDifficulty
{
    [Display(Name = "Einfach")]
    Easy = 0,
    [Display(Name = "Mittel")]
    Medium = 1,
    [Display(Name = "Schwer")]
    Hard = 2
}