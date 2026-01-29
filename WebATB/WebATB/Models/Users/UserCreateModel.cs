using System.ComponentModel.DataAnnotations;

namespace WebATB.Models.Users
{
    public class UserCreateModel
    {
        [Display(Name = "Прізвище")]
        [Required(ErrorMessage = "Вкажіть прізвище")]
        public string LastName { get; set; } = string.Empty;
        [Display(Name="Ім'я")]
        [Required(ErrorMessage = "Вкажіть ім'я")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Вкажіть номер телефону")]
        public string Phone { get; set; } = string.Empty;
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Вкажіть email")]
        public string Email { get; set; } = string.Empty;
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Вкажіть пароль")]
        public string Password { get; set; } = string.Empty;
        [Display(Name = "Фото")]
        [Required(ErrorMessage = "Вкажіть фото")]
        public string Photo { get; set; } = string.Empty;
    }
}
