using Microsoft.EntityFrameworkCore;
using WebATB.Data.Entities;

namespace WebATB.Data;

public class MyContextATB : DbContext
{
    //Шаблони для створення екземплярів DbContext
    //із впровадженням залежностей або без нього
    //також керування такими екземплярами
    public MyContextATB(DbContextOptions<MyContextATB> contextOptions)
        : base(contextOptions)
    {
        
    }
    //створення категорій
    public DbSet<CategoryEntity> Categories { get; set; }
}