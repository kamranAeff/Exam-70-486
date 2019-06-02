using Chapter06.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Chapter06.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calc;
        private Product[] products = {
             new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
             new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
             new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
             new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
             };

        public HomeController(IValueCalculator calc, IValueCalculator calc2, IValueCalculator calc3)
        {
            this.calc = calc;
        }

        // GET: Home
        async public Task<ActionResult> Index()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return await Task.FromResult(View(totalValue));
        }
    }
}