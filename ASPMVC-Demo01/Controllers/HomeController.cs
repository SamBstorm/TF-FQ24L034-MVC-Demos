using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPMVC_Demo01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Demo01()
        {
            return View();
        }

        public IActionResult Demo02(int? id)
        {
            ViewData["text"] = $"Voici un exemple de texte provenant directement du controller : {nameof(HomeController)}";
            ViewData["id"] = id;
            return View();
        }
    }
}
