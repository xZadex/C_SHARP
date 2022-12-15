#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TheWall.Models;
public class Comment
{
    [Key]
    public int CommentId {get;set;}

    [Required]
    public string Content {get;set;}

    public int MessageId {get;set;}

    public int UserId {get;set;}

    // navigation property
    public User? Creator {get;set;}
    public List<Association> Users {get;set;} = new List<Association>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}