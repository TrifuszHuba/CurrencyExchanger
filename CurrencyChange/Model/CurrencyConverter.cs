using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using CurrencyChange.ViewModel;

namespace CurrencyChange.Model
{
    public class CurrencyConverter
    {
        public Currency Base { get; set; }
        public List<Currency> CurrencyList { get; set; }
        public int amount;

        public CurrencyConverter(CurrencyChangeVM vm) 
        {
            Base = new Currency("USD", "United States Dollar", vm);
            CurrencyList = new List<Currency>
            {
                new Currency("EUR", "Euro", vm),
                new Currency("HUF", "Hungarian Forint", vm)
            };
        }
    }
}
