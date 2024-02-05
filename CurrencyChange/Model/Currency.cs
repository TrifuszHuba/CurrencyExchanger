using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyChange.Model
{
    public class Currency
    {
        public string Abbreviation { get; set; }
        public string FullName { get; set; }
        public float RelativeValue { get; set; }

        public Currency(string abbreviation, string fullName)
        {
            Abbreviation = abbreviation;
            FullName = fullName;
            RelativeValue = 0f;
        }
    }
}
