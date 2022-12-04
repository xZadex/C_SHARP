#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Session_Workshop.Models;

public class Form
{
    [Required]
    public string Name{ get; set; }

}
