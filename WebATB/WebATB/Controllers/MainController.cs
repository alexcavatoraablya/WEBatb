using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebATB.Models.Users;

namespace WebATB.Controllers;

public class MainController : Controller
{
    static List<UserItemModel> list =
    new()
    {
        new ()
        {
            Id = 1,
            Name = "Вікторович Віктор Йосипович",
            Phone = "098221546781",
            Image = "blank-pfp.png"
        },

        new ()
        {
            Id = 2,
            Name = "Рижий Марко Йосипович",
            Phone = "098564783209",
            Image = "long.jpg"
        },

        new ()
        {
            Id = 3,
            Name = "Галоша Іванна Ігорівна",
            Phone = "098264284327",
            Image = "opossum.jpg"
        }
    };
    public IActionResult Index()
    {
        return View(list);
    }
    [HttpGet] //метод для відображення сторінки
    public IActionResult Create()
    {

        return View();

    }

    [HttpPost] //метод для відображення сторінки
    public IActionResult Create(UserCreateModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        //якщо модель валідна то дані буде зберігати у список і переходимо на іншу сторінку
        UserItemModel item = new UserItemModel
        {
            Id = list.Count + 1,
            Name = model.LastName + " "
                + model.Name + " ",
            Phone = model.Phone,
            //Image = model.ImageUrl
        };

        if (model.ImageUrl != null)
        {
            var dir = Directory.GetCurrentDirectory();
            var wwwroot = "wwwroot";
            var fileName = Guid.NewGuid().ToString() + ".jpg";
            var savePath = Path.Combine(dir, wwwroot, "images", fileName);
            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                model.ImageUrl.CopyTo(stream);
            }
            item.Image = fileName;
        }
        list.Add(item);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        //шукаю елемента в списку по id 
        var item = list.SingleOrDefault(x => x.Id == id);
        return View(item);
    }

    [HttpPost]
    public IActionResult Delete(UserItemModel user)
    {
        //шукаю елемента в списку по id 
        var item = list.SingleOrDefault(x => x.Id == user.Id);
        list.Remove(item);
        return RedirectToAction(nameof(Index));
    }
}