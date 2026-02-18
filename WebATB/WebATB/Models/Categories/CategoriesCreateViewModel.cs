namespace WebATB.Models.Categories;

public class CategoriesCreateViewModel
{
    public string CategoryName { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public IFormFile? FileImage { get; set; }
}
