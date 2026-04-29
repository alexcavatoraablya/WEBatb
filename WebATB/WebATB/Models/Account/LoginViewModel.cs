using System.ComponentModel.DataAnnotations;

namespace WebATB.Models.Account;

public class LoginViewModel
{
    [Display(Name = "Електрона пошта")]
    [Required(ErrorMessage = "Вкажіть Електрону пошту")]
    [EmailAddress(ErrorMessage = "Невірно вказали пошту")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Пароль")]
    [Required(ErrorMessage = "Вкажіть Пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}
