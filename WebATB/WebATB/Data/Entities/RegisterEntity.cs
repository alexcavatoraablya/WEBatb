using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebATB.Data.Entities;

//створення таблиці
[Table("tblRegister")]
public class RegisterEntity
{
    //унікальний індентифікатор (ключ)
    [Key]
    public int Id { get; set; } //створення властивості
    [Required, StringLength(250)] //розмір символів та встановлення атрибута
    public string Name { get; set; } = null!;
    [Required, StringLength(250)]
    public string? Image { get; set; } = string.Empty;
}
