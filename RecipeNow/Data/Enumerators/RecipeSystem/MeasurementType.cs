namespace RecipeNow.Data.Enumerators;
using System.ComponentModel.DataAnnotations;
public enum MeasurementType
{
    [Display(Name = "Gram")]
    Gram = 0,
    [Display(Name = "Mililiter")]
    Mililiter = 1,
    [Display(Name = "Stück")]
    Pieces = 2
}
