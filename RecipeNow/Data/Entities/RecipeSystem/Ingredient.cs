using RecipeNow.Data.Enumerators;
using System.ComponentModel.DataAnnotations;
namespace RecipeNow.Data.Entities.RecipeSystem;



public class Ingredient
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    public required float PricePerUnit { get; set; }
    
    [Required]
    public required MeasurementType Measurement { get; set;}
}