namespace RecipeNow.Data.Enumerators;
using System.ComponentModel.DataAnnotations;
public enum MeasurementType
{
    [Display(Name = "Kilogram")]
    Kilogram = 0,
    [Display(Name = "Liter")]
    Liter = 1,
    [Display(Name = "Stück")]
    Pieces = 2
}
