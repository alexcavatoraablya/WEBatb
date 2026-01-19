using Microsoft.AspNetCore.Mvc;
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
            Phone = "098221546781"
        });

        model.Add(new UserItemModel
        {
            Id = 1,
            Name = "Рижий Марко Йосипович",
            Phone = "098564783209"
        });

        model.Add(new UserItemModel
        {
            Id = 1,
            Name = "Галоша Іванна Ігорівна",
            Phone = "098264284327"
        });

        return View(model);
    }
}
