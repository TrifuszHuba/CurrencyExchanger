using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyChange.Model
{
    public class CurrencyConverter
    {
        public Currency Base { get; set; }
        public List<Currency> CurrencyList { get; set; }
    }
}
