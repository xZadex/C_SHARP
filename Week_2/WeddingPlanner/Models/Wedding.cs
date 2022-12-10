#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
public class Wedding
{
    [Key]
    public int WeddingId {get;set;}

    [Required]
    [MinLength(2, ErrorMessage ="Wedder name must be at least 2 characters")]
    public string WedderOne { get; set; }

    [Required]
    [MinLength(2, ErrorMessage ="Wedder name must be at least 2 characters")]
    public string WedderTwo { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime WeddingDate {get;set;}

    [Required]
    [MinLength(8, ErrorMessage ="Address must be at least 8 characters.")]
    public string WeddingAddress {get;set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}