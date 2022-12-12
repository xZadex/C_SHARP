#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;
public class WeddingAssociation
{
    [Key]    
    public int WeddingAssociationId { get; set; } 
    
    // ids   
    public int UserId { get; set; }    
    public int WeddingId { get; set; }


    // navigation
    public User? User { get; set; }    
    public Wedding? Wedding { get; set; }
}