using System.ComponentModel.DataAnnotations;
using RecipeNow.Data.Enumerators;

namespace RecipeNow.Data.Entities.RecipeSystem;

public class Shelf
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Darf nicht leer sein")]
    [MaxLength(100,ErrorMessage = "Darf nicht länger als 100 Charaktere sein sein")]
    public string ContentDescription { get; set; }
    
    [Required(ErrorMessage = "Darf nicht leer sein")]
    public int Height { get; set; }
    
    [Required(ErrorMessage = "Darf nicht leer sein")]
    public int Width{ get; set; }
    
    
    [Required(ErrorMessage = "Darf nicht leer sein")]
    public int StorageRoomId { get; set; }
    
    [Required(ErrorMessage = "Darf nicht leer sein")]
    public ICollection<ShelfIngredient> ShelfIngredients{ get; set; }
        = new List<ShelfIngredient>();
    
    
}