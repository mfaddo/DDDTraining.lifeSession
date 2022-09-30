using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Domain
{
   public class Price :Money
    {
        public Price(decimal amount,string cur
            , ICurrencyLookup currencyLookup) :
            base(amount, cur, currencyLookup)
        {
            if (amount < 0)
                throw new ArgumentException(
                "Price cannot be negative",
                nameof(amount));
        }

        internal Price(decimal amount, string currencyCode)
         : base(amount, new CurrencyDetails { CurrencyCode = currencyCode })
        {
        }

        public new static Price FromDecimal(decimal amount, string currency,
       ICurrencyLookup currencyLookup) =>
       new Price(amount, currency, currencyLookup);
    }
}
