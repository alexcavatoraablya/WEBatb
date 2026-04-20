using Microsoft.AspNetCore.Mvc;
using WebATB.Data;
using WebATB.Data.Entities;
using WebATB.Models.Categories;

namespace WebATB.Controllers;
public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    

}
