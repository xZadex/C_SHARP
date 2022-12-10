#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;
public class Association
{
    [Key]    
    public int AssociationId { get; set; } 
    
    // The IDs linking to the adjoining tables   
    public int ProductId { get; set; }    
    public int CategoryId { get; set; }


    // Our navigation properties - don't forget the ?    
    public Product? Product { get; set; }    
    public Category? Category { get; set; }
}