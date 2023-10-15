using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Domain
{
    [AsChoice]
    public static partial class ShoppingCartPayedEvent
    {
        public interface IShoppingCartPayedEvent { }

        public record ShoppingCartPaySuccededEvent : IShoppingCartPayedEvent
        {
            public decimal Total { get; }

            public ShoppingCartPaySuccededEvent(decimal total)
            {
                Total = total;
            }
        }

        public record ShoppingCartPayFailedEvent : IShoppingCartPayedEvent
        {
            public string Reason { get; }

            public ShoppingCartPayFailedEvent(string reason)
            {
                Reason = reason;
            }
        }
    }
}
