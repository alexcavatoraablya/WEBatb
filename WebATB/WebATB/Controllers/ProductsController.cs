using Microsoft.AspNetCore.Mvc;
using WebATB.Data;
using WebATB.Data.Entities;
using WebATB.Models.Categories;
using WebATB.Models.Products;

namespace WebATB.Controllers
{
    public class ProductsController(MyContextATB myContextATB) : Controller
    {
        public IActionResult Index()
        {
            var products = myContextATB.Products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Slug = p.Slug,
                Price = p.Price.ToString(),
                Sale = p.Sale.ToString(),
                CategoryName = p.Category.Name,
                FileImage = p.Image
            }).ToList();

            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ProductCreateViewModel model = new ProductCreateViewModel();
            //динамічна колекція
            //тут буде список категорій
            ViewBag.Categories = myContextATB.Categories.ToList();

            return View(model);
        }
        [HttpPost]
        public IActionResult Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid) //Зберігаємо категорію в БД, якщо модель валідна
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
                //Заповнюю таблицю категорій в БД
                var product = new ProductEntity
                {
                    Name = model.Name,
                    Slug = model.Slug,
                    Price = decimal.Parse(model.Price),
                    Description = model.Description,
                    GeneralInfo = model.GeneralInfo,
                    CategoryId = model.CategoryId,
                    Image = fileName
                };
                myContextATB.Products.Add(product); //Роблю SQL запит INSERT
                myContextATB.SaveChanges(); //Зберігаю зміни в БД - Викную SQL запит COMMIT
                return RedirectToAction(nameof(Index));
            }
            return View(model); // Якщо модель не валідна, повертаємо її назад на форму для виправлення помилок
        }

        [HttpGet] //id - це параметр, який ми передаємо в URL, наприклад: /Categories/Edit/5
        public IActionResult Edit(int id)
        {
            var prod = myContextATB.Products.FirstOrDefault(c => c.Id == id);
            if (prod == null)
            {
                return NotFound(); //Якщо категорія не знайдена, повертаємо 404 помилку
            }
            //створення нового елемента в списку
            var model = new ProductEditViewModel
            {
                Id = prod.Id,
                Name = prod.Name,
                Slug = prod.Slug,
                CategoryId = prod.CategoryId,
                Description = prod.Description,
                GeneralInfo = prod.GeneralInfo,
                Price = prod.Price.ToString(),
                OldImage = prod.Image
            };
            //повертає дію
            ViewBag.Categories = myContextATB.Categories.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ProductEditViewModel model)
        {
            var product = myContextATB.Products.Find(model.Id); //Знаходимо категорію за id
            if (ModelState.IsValid) //Зберігаємо категорію в БД, якщо модель валідна
            {
                //Зберігаємо старе фото
                string fileName = product.Image;
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
                //Заповнюю таблицю категорій в БД
                product.Name = model.Name;
                product.Image = fileName;
                product.Slug = model.Slug;
                product.CategoryId = model.CategoryId;
                product.GeneralInfo = model.GeneralInfo;
                product.Price = decimal.Parse(model.Price);


                myContextATB.SaveChanges(); //Зберігаю зміни в БД - Викную SQL запит COMMIT
                return RedirectToAction(nameof(Index));
            }

            return View(model); // Якщо модель не валідна, повертаємо її назад на форму для виправлення помилок
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = myContextATB.Products.Find(id); //Знаходимо категорію за id
            if (product != null)
            {
                var dir = Directory.GetCurrentDirectory();
                var wwwroot = "wwwroot";
                string fileName = product.Image;
                var savePath = Path.Combine(dir, wwwroot, "images", fileName);
                if (System.IO.File.Exists(savePath) && fileName != "default.jpg")
                {
                    System.IO.File.Delete(savePath); //Видаляємо файл з диску
                }
                myContextATB.Products.Remove(product); //Робимо SQL запит DELETE
                myContextATB.SaveChanges(); //Зберігаємо зміни в БД - Викную SQL запит COMMIT
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
