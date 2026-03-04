using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebATB.Data.Entities;

//створення таблиці
[Table("tblProducts")]
public class ProductEntity
{
    //унікальний індентифікатор (ключ)
    [Key]
    public int ProductId { get; set; } //створення властивості
    [Required, StringLength(250)] //розмір символів та встановлення атрибута
    public string ProductName { get; set; } = null!;
    [Required, StringLength(250)]
    public string? Image { get; set; } = string.Empty;

    public ICollection<CategoryEntity> Products { get; set; }
}
