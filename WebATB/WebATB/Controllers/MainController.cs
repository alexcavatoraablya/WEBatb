using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebATB.Models.Users;

namespace WebATB.Controllers;

public class MainController : Controller
{
    public IActionResult Index()
    {
        List<UserItemModel> model = new List<UserItemModel>();
        model.Add(new UserItemModel
        {
            Id = 1,
            Name = "Вікторович Віктор Йосипович",
            Phone = "098221546781",
            Image = "blank-pfp.png"
        });

        model.Add(new UserItemModel
        {
            Id = 2,
            Name = "Рижий Марко Йосипович",
            Phone = "098564783209",
            Image = "long.jpg"
        });

        model.Add(new UserItemModel
        {
            Id = 3,
            Name = "Галоша Іванна Ігорівна",
            Phone = "098264284327",
            Image = "opossum.jpg"
        });

        return View(model);
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
        return RedirectToAction(nameof(Index));
    }
    
}
