using System.Collections.Generic;
using System.Linq;

namespace Chapter06.WebUI.Models
{
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscountHelper discounter;
        private static int counter = 0;
        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
            
            System.Diagnostics.Debug.WriteLine(string.Format("Instance {0} created", ++counter));
        }
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}