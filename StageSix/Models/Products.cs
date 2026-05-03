using System.ComponentModel.DataAnnotations.Schema;

namespace StageSix.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public bool Status { get; set; }
    public DateTime Mfg { get; set; }
    public string? Photo { get; set; }

    [NotMapped]
    public string StatusDisplay => Status ? "In stock" : "Out of stock";
}