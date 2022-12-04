#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Form_Submission.Models;

public class Survey
{
    [Required]
    [MinLength(2,ErrorMessage = "Name must be at least 2 characters.")]
    public string Name{get;set;}

    [Required]
    [EmailAddress]
    public string Email{get;set;}

    [Required]
    [DataType(DataType.Date)]
    [FutureDate]

    public DateTime Birthday{get;set;}

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8,ErrorMessage = "Password must be at least 8 characters.")]
    public string password{get;set;}

    [Required]
    [OddNumber]
    public int FavoriteOddNumber{get;set;}
}

public class FutureDateAttribute : ValidationAttribute
{    
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)    
    {       
        if (((DateTime?)value) > DateTime.Today)
        {        
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Provide an earlier date");   
        } else { 
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;  
        }
    }
}


public class OddNumber : ValidationAttribute
{    
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)    
    {       
        if (((int?)value) % 3 != 0)
        {        
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Provide an Odd Number");   
        } else { 
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;  
        }
    }
}