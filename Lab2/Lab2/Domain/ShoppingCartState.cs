using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Domain
{
    [AsChoice]
    public static partial class ShoppingCartState
    {
        public interface IShoppingCartState { }

        public record EmptyShoppingCart(IReadOnlyCollection<UnvalidatedShoppingCartProduct> shoppingCartList) : IShoppingCartState;

        public record UnvalidatedShoppingCart(IReadOnlyCollection<UnvalidatedShoppingCartProduct> shoppingCartList, string reason) : IShoppingCartState;

        public record ValidatedShoppingCart(IReadOnlyCollection<ValidatedShoppingCartProduct> shoppingCartList) : IShoppingCartState;

        public record PayedShoppingCart(IReadOnlyCollection<ValidatedShoppingCartProduct> shoppingCartList) : IShoppingCartState;
    }
}
