#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TheWall.Models;
public class User
{
    [Key]
    public int UserId {get;set;}

    [Required]
    [MinLength(2, ErrorMessage ="First Name must be at least 2 characters")]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2, ErrorMessage ="First Name must be at least 2 characters")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email { get; set; }

    [Required]
    [MinLength(2, ErrorMessage ="Password must be at least 8 characters.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password")]
    [Display(Name = "Confirm Password")]
    public string Confirm { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // navigation property
    public List<Message> CreatedMessages { get; set; } = new List<Message>();
    public List<Association> Comments {get;set;} = new List<Association>();
}

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
        {
            return new ValidationResult("Email is required.");
        }

        MyContext? _context = (MyContext)validationContext.GetService(typeof(MyContext));
        if(_context.Users.Any(e => e.Email == value.ToString()))
        {
            return new ValidationResult("Email must be unique!");
        } else {
            return ValidationResult.Success;
        }
    }
}