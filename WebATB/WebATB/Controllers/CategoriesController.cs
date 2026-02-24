using Microsoft.AspNetCore.Mvc;
using WebATB.Data;
using WebATB.Data.Entities;
using WebATB.Models.Categories;

namespace WebATB.Controllers;
//робимо Injection для роботи з БД, але покеи що просто виводимо сторінку
public class CategoriesController(MyContextATB myContextATB) : Controller
{
    public IActionResult Index()
    {
        var categories = myContextATB.Categories.ToList();
        return View(categories);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(CategoriesCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            string fileName = "default.jpg";
            //Як зберегти фото
            if (model.FileImage != null)
            {
                var dir = Directory.GetCurrentDirectory();
                var wwwroot = "wwwroot";
                fileName = Guid.NewGuid().ToString() + ".jpg";
                var savePath = Path.Combine(dir, wwwroot, "images", fileName);
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    model.FileImage.CopyTo(stream);
                }
            }
            var categoty = new CategoryEntity
            {
                Name = model.CategoryName,
                Slug = model.Slug,
                Image = fileName
            };
            myContextATB.Categories.Add(categoty);
            myContextATB.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }
}
