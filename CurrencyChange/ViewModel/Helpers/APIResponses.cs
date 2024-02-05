using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyChange.ViewModel.Helpers
{
    public class GetCurrenciesResponse
    {
        public bool Success { get; set; }
        public Dictionary<string, string> Result { get; set; }
    }
    public class GetConversionRatesResponse
    {
        public bool Success { get; set; }
        public string Timestamp { get; set; }
        public string Date {  get; set; }
        public Dictionary<string, string> Result { get; set; }
    }
}
