using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyChange.Model
{
    public class CurrencyConverter
    {
        public Currency Base { get; set; }
        public List<Currency> CurrencyList { get; set; }
        public int amount;

        public CurrencyConverter() 
        {
            Base = new Currency("USD", "United States Dollar");
            CurrencyList = new List<Currency>
            {
                new Currency("EUR", "Euro"),
                new Currency("HUF", "Hungarian Forint")
            };
        }
    }
}
