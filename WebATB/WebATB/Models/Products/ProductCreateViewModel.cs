using System.ComponentModel.DataAnnotations;

namespace WebATB.Models.Products;

public class ProductCreateViewModel
{
    [Display(Name = "Категорія")]
    [Required(ErrorMessage = "Вкажіть категорію")]
    public int CategoryId { get; set; }
    [Display(Name = "Назва")]
    [Required(ErrorMessage = "Вкажіть назву")]
    public string Name { get; set; } = String.Empty;
    [Display(Name = "Slug")]
    [Required(ErrorMessage = "Вкажіть slug")]
    public string Slug { get; set; } = String.Empty;
    [Display(Name = "Ціна")]
    [Required(ErrorMessage = "Вкажіть ціну")]
    public string Price { get; set; } = String.Empty;
    [Display(Name = "Знижка")]
    [Required(ErrorMessage = "Вкажіть знижку")]
    public string Sale { get; set; } = String.Empty;
    [Display(Name = "Опис")]
    [Required(ErrorMessage = "Вкажіть опис")]
    public string Description { get; set; } = String.Empty;
    [Display(Name = "Короткий опис")]
    [Required(ErrorMessage = "Вкажіть короткий опис")]
    public string GeneralInfo { get; set; } = String.Empty;
    [Display(Name = "Фото")]
    [Required(ErrorMessage = "Вкажіть фото")]
    public IFormFile? FileImage { get; set; }
}
