using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Domain
{
    public record PayShoppingCartCommand
    {
        public PayShoppingCartCommand(IReadOnlyCollection<UnvalidatedShoppingCartProduct> products) {
            InputProducts = products;
        }

        public IReadOnlyCollection<UnvalidatedShoppingCartProduct> InputProducts { get; }
    }
}
