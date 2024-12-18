using Microsoft.AspNetCore.Mvc;

namespace ASPMVC_Demo01.Controllers
{
    public class ShopController : Controller
    {
        private string[] _products = ["Tickets de loterie", "Montre", "Vin", "Parfum", "Chaussettes"];
        [ViewData]
        public string Title { get; set; }
        [ViewData]
        public string[] Products { get { return _products; } }
        public IActionResult Index()
        {
            Title = "Liste des produits";
            //ViewData["products"] = _products;
            return View();
        }

        public IActionResult Details(int id)
        {
            try
            {
                if (id < 0) throw new ArgumentOutOfRangeException(nameof(id), "Indice ne peut être en dessous de 0");
                if (id >= _products.Length) throw new ArgumentOutOfRangeException(nameof(id), $"Indice ne peut être au dessus de {_products.Length - 1}");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            Title = $"Vue détaillée de {_products[id]}";
            ViewData["product"] = _products[id];
            return View();
        }
    }
}
