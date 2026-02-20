namespace RecipeNow.Data.Enumerators;
using System.ComponentModel.DataAnnotations;
public enum MeasurementType
{
    [Display(Name = "g")]
    Gram = 0,
    [Display(Name = "ml")]
    Milliliter = 1,
    [Display(Name = "Stk")]
    Pieces = 2
}
