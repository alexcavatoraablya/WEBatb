using System.ComponentModel.DataAnnotations;

namespace WebATB.Models.Products;

public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Slug { get; set; } = String.Empty;
    public string Price { get; set; } = String.Empty;
    public string Sale { get; set; } = String.Empty;
    public string CategoryName {  get; set; } = String.Empty;
    public string? FileImage { get; set; }
}
