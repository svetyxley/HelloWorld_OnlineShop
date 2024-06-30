using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BusinessLayer.Constants
{
    public record exchangeRateOnDate(DateOnly dateOfCurrencyExchange, Currency currency1, Currency currency2, decimal currency1_to_currency2);


   public enum Currency
    {
        USD,
        EUR,
        UAH,
        FXB
    }
}
