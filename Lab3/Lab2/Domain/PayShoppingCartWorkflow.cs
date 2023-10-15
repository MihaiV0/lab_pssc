using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab2.Domain.ShoppingCartPayedEvent;
using static Lab2.Domain.ShoppingCartState;
using static Lab2.Domain.ShoppingCartStateOperations;

namespace Lab2.Domain
{
    internal class PayShoppingCartWorkflow
    {
        public IShoppingCartPayedEvent Execute(PayShoppingCartCommand command, Func<ProductName, bool> checkProductExists)
        {
            EmptyShoppingCart emptyShoppingCart = new EmptyShoppingCart(command.InputProducts);
            IShoppingCartState shoppingCartState = ValidateShoppingCart(checkProductExists, emptyShoppingCart);
            shoppingCartState = CalculatePrice(shoppingCartState);
            shoppingCartState = PayShoppingCart(shoppingCartState);

            return shoppingCartState.Match(
                whenEmptyShoppingCart: emptyShoppingCart => new ShoppingCartPayFailedEvent("Unexpected result") as IShoppingCartPayedEvent,
                whenUnvalidatedShoppingCart: unvalidatedShoppingCart => new ShoppingCartPayFailedEvent(unvalidatedShoppingCart.Reason),
                whenValidatedShoppingCart: validatedShoppingCart => new ShoppingCartPayFailedEvent("Unexpected result"),
                whenCalculatedShoppingCart: calculatedShoppingCart => new ShoppingCartPayFailedEvent("Unexpected result"),
                whenPayedShoppingCart: payedShoppingCart => new ShoppingCartPaySuccededEvent(payedShoppingCart.Total)
                );
        }
    }
}
