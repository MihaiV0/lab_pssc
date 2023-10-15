using Lab2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab2.Domain.ShoppingCartState;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = ReadListOfProducts().ToArray();
            UnvalidatedShoppingCart unvalidatedShoppingCart = new(products, "");
            IShoppingCartState result = ValidateShoppingCart(unvalidatedShoppingCart);
            result.Match(
                whenEmptyShoppingCart: emptyShoppingCart => emptyShoppingCart,
                whenUnvalidatedShoppingCart: unvalidatedShoppingCart => unvalidatedShoppingCart,
                whenValidatedShoppingCart: validatedShoppingCart => validatedShoppingCart,
                whenPayedShoppingCart: payedShoppingCart => PayShoppingCart(payedShoppingCart)
                );

            Console.WriteLine("Done");
        }

        private static List<UnvalidatedShoppingCartProduct> ReadListOfProducts()
        {
            List<UnvalidatedShoppingCartProduct> listOfProducts = new();
            do
            {
                var productName = ReadValue("Product name: ");
                if (string.IsNullOrEmpty(productName))
                {
                    break;
                }

                var price = ReadValue("Price: ");
                if (string.IsNullOrEmpty(price))
                {
                    break;
                }

                listOfProducts.Add(new(productName, price));
            } while (true);
            return listOfProducts;
        }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private static IShoppingCartState ValidateShoppingCart(UnvalidatedShoppingCart unvalidatedShoppingCart) =>
            unvalidatedShoppingCart.shoppingCartList.Count == 0 ? 
            new EmptyShoppingCart(new List<UnvalidatedShoppingCartProduct>()) :
            unvalidatedShoppingCart.shoppingCartList.Count <= 1 ?
            new UnvalidatedShoppingCart(new List<UnvalidatedShoppingCartProduct>(), "error") :
            new ValidatedShoppingCart(new List<ValidatedShoppingCartProduct>());

        private static IShoppingCartState PayShoppingCart(PayedShoppingCart payedShoppingCart) =>
            new PayedShoppingCart(new List<ValidatedShoppingCartProduct>());
    }
}
