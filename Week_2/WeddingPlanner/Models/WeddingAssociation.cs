#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;
public class WeddingAssociation
{
    [Key]    
    public int WeddingAssociationId { get; set; } 
    
    // The IDs linking to the adjoining tables   
    public int UserId { get; set; }    
    public int WeddingId { get; set; }


    // Our navigation properties - don't forget the ?    
    public User? User { get; set; }    
    public Wedding? Wedding { get; set; }
}