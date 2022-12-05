#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace LINQ_Demo.Models;

public class Game
{
    public string Title{ get; set; }
    public double Price{ get; set; }
    public string Genre{ get; set; }
    public string Rating{ get; set; }
    public string Platform{ get; set; }

}