using System.ComponentModel.DataAnnotations;

namespace WebATB.Models.Categories
{
    public class CategoriesCreateModel
    {
        [Display(Name = "Назва")]
        [Required(ErrorMessage = "Вкажіть назву")]
        public string CategoryName { get; set; } = string.Empty;
        [Display(Name = "Slug")]
        [Required(ErrorMessage = "Вкажіть Slug")]
        public string Slug { get; set; } = string.Empty;

        [Display(Name = "Фото url")]
        [Required(ErrorMessage = "Вкажіть фото url")]
        public IFormFile? FileImage { get; set; } = null!;
    }
}
