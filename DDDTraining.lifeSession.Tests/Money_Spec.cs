using DDDTraining.lifeSession.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DDDTraining.lifeSession.Tests
{
    public class Money_Spec
    {
        private static readonly ICurrencyLookup CurrencyLookup =
        new FakeCurrencyLookup();

        [Fact]
        public void Two_of_same_amount_should_be_equal()
        {
            var firstAmount = Money.FromDecimal(5, "EUR",
            CurrencyLookup);
            var secondAmount = Money.FromDecimal(5, "EUR",
            CurrencyLookup);
            Assert.Equal(firstAmount, secondAmount);
        }
    }
}
