using Chapter06.Core.Infrastructure;
using Chapter06.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06
{
    class Program
    {
        static private Product[]
            products = new[]{
                new Product { Name = "Kayak", Category = "Watersports", Price = 275M },
                new Product { Name = "Lifejacket", Category = "Watersports", Price = 48.95M },
                new Product { Name = "Soccer ball", Category = "Soccer", Price = 19.50M },
                new Product { Name = "Corner flag", Category = "Soccer", Price = 34.95M }
                };

        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

            IValueCalculator calc = kernel.Get<IValueCalculator>();
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();

        }
    }
}
