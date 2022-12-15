#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace TheWall.Models;
public class Association
{
    [Key]    
    public int AssociationId { get; set; } 
    
    // ids   
    public int UserId { get; set; }    
    public int CommentId { get; set; }


    // navigation
    public User? User { get; set; }    
    public Comment? Comment { get; set; }
}