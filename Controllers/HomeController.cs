using MeuSiteEmMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MeuSiteEmMVC.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()  // Startup onde inicia o programa
        {
            HomeModel home = new HomeModel();

            home.Nome = "Acaciano Neves";
            home.email = "acaciano.neves@gmail.com";

            return View(home);
        }

        public IActionResult Privacy() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}