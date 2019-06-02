using Chapter06.Core.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Chapter06.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return products.Sum(p => p.Price);
        }
    }
}
