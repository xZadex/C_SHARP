#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;
public class Dish
{
    [Key]

    [Required]
    public int DishId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Chef { get; set; }

    [Required]
    [Range(1,5,ErrorMessage="Tastiness field is required.")]
    public int Tastiness { get; set; }


    [GreaterThanZero]
    [Required]
    public int? Calories { get; set; }

    [Required]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

public class GreaterThanZero : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {     
        if(value != null)
        {
            if (((int)value) < 0)
            {        
                // we return an error message in ValidationResult we want to render    
                return new ValidationResult("Calories must be more than 0");   
            }
        }
            return ValidationResult.Success;  
    }
}