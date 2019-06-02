using Chapter06.Models;
using System.Collections.Generic;

namespace Chapter06.Core.Infrastructure
{
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
}
