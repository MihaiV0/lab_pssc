using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public record Order
    {
        public Person Person { get; init; }
        public List<Product> Products { get; init; }
    }
}
