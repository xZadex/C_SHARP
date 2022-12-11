#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
public class Wedding
{
    [Key]
    public int WeddingId {get;set;}

    [Required(ErrorMessage="Please enter a name for Wedder One.")]
    [MinLength(2, ErrorMessage ="Wedder name must be at least 2 characters")]
    public string WedderOne { get; set; }

    [Required(ErrorMessage="Please enter a name for Wedder Two.")]
    [MinLength(2, ErrorMessage ="Wedder name must be at least 2 characters")]
    public string WedderTwo { get; set; }

    [Required(ErrorMessage="Please select a date")]
    [DataType(DataType.Date)]
    [PastDate]
    public DateTime WeddingDate {get;set;}

    [Required(ErrorMessage="Please enter an address for the wedding.")]
    [MinLength(8, ErrorMessage ="Address must be at least 8 characters.")]
    public string WeddingAddress {get;set;}

    public int CreatorId {get;set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    // navigation
    public User? UserName { get; set; }

    public List<WeddingAssociation> GuestList {get;set;} = new List<WeddingAssociation>();
}


public class PastDateAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {       
        if (((DateTime)value) < DateTime.Today)
        {        
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Provided an valid future date");   
        } else { 
            // Otherwise, we were successful and can report our success  
            Console.WriteLine("Date provided successfully!");  
            return ValidationResult.Success;  
        }
    }
}