#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TheWall.Models;
public class Message
{
    [Key]
    public int MessageId {get;set;}

    [Required]
    public string Content {get;set;}

    public int UserId {get;set;}

    // navigation property
    public User? Creator {get;set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}