using ASPMVC_Demo01.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPMVC_Demo01.Controllers
{
    public class ShopController : Controller
    {
        private Product[] _products = [
            new Product(){Name = "Tickets de loterie", Price = 2.5M, Quantity=100 },
            new Product(){Name = "Montre", Price = 250M, Quantity = 10},
            new Product(){Name = "Vin", Price = 15M, Quantity = 75 },
            new Product(){Name = "Parfum", Price = 50M, Quantity = 25 },
            new Product(){Name = "Chaussettes", Price = 7.5M, Quantity = 0 }];
        [ViewData]
        public string Title { get; set; }
        public IActionResult Index()
        {
            Title = "Liste des produits";
            IEnumerable<ProductListItem> model = _products
                .Select(p => new ProductListItem() { Name = p.Name, Price = p.Price}) ;
            return View(model);
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
            Product model = _products[id];
            Title = $"Vue détaillée de {model.Name}";
            return View(model);
        }
    }
}
