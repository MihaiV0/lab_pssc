using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Lab1.Quantity;

namespace Lab1
{
    public class Product
    {
        public string Code { get; set; }
        public IQuantity Quantity { get; set; }

        public override string ToString()
        {
            return $"Product: {Code}, {Quantity}";
        }
    }
}
