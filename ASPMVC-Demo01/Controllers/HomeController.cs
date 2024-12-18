using Microsoft.AspNetCore.Http.Extensions;
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
            SaveCurrentUrl(HttpContext.Request.GetDisplayUrl());
            return View();
        }

        public IActionResult Demo01()
        {
            SaveCurrentUrl(HttpContext.Request.GetDisplayUrl());
            return View();
        }

        public IActionResult Demo02(int? id)
        {
            SaveCurrentUrl(HttpContext.Request.GetDisplayUrl());
            ViewData["text"] = $"Voici un exemple de texte provenant directement du controller : {nameof(HomeController)}";
            ViewBag.id = id;
            return View();
        }

        public IActionResult Demo04() {
            SaveCurrentUrl(HttpContext.Request.GetDisplayUrl());
            ViewData["text"] = "Je suis un message venant de l'action Demo04 et sauvé dans le ViewData.";
            TempData["text"] = "Je suis un message venant de l'action Demo04 et sauvé dans le TempData.";
            return RedirectToAction(nameof(Demo04ShowMessage));
        }
        public IActionResult Demo04ShowMessage()
        {
            SaveCurrentUrl(HttpContext.Request.GetDisplayUrl());
            TempData.Keep("text");
            return View();
        }

        public IActionResult Demo04TestMessage() {
            SaveCurrentUrl(HttpContext.Request.GetDisplayUrl());
            return View();
        }

        public IActionResult Demo05()
        {
            SaveCurrentUrl(HttpContext.Request.GetDisplayUrl());
            return View();
        }

        private void SaveCurrentUrl(string url)
        {
            if (TempData.ContainsKey("URLs"))
            {
                string[] urls = ((string[])TempData["URLs"]);
                List<string> urls_list = new List<string>(urls);
                urls_list.Add(url);
                TempData["URLs"] = urls_list;
            }
            else
            {
                TempData["URLs"] = new List<string>([url]);
            }
            TempData.Keep("URLs");
        }
    }
}
