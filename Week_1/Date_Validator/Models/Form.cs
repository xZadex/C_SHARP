#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Date_Validator.Models;

public class Form
{

    [FutureDate]
    public DateTime? Date{get;set;}
}

public class FutureDateAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {       
        if (((DateTime)value) > DateTime.Today)
        {        
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Provided an earlier date");   
        } else { 
            // Otherwise, we were successful and can report our success  
            Console.WriteLine("Date provided successfully!");  
            return ValidationResult.Success;  
        }
    }
}