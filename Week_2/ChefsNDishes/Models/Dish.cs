#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [Range(1,int.MaxValue,ErrorMessage = "Pick a number greater than 0.")]
    public int? Calories { get; set; }

    [Required]
    [Range(1,int.MaxValue,ErrorMessage ="Please select a Chef.")]
    public int ChefId { get; set; }

    [Required]
    [Range(1,5,ErrorMessage="Must pick an option between 1 and 5.")]
    public int Tastiness { get; set; }

    // navigation 
    public Chef? ChefName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}