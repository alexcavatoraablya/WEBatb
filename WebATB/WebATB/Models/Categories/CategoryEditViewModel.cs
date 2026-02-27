using System.ComponentModel.DataAnnotations;

namespace WebATB.Models.Categories;

public class CategoryEditViewModel
{
    public int Id { get; set; } //зчитується з id
    [Display(Name = "Вкажіть назву категорії")]
    [Required(ErrorMessage = "Вкажіть назву категорії")]
    public string CategoryName { get; set; } = null!;
    [Display(Name = "Вкажіть Slug")]
    [Required(ErrorMessage = "Вкажіть Slug")]
    public string Slug { get; set; } = null!;
    public string ? OldImage { get; set; }
    [Display(Name = "Вкажіть фото")]
    [Required(ErrorMessage = "Вкажіть фото")]
    public IFormFile? FileImage { get; set; }
}
