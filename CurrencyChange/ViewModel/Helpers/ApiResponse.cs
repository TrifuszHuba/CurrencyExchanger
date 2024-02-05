using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyChange.ViewModel.Helpers
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public Dictionary<string, string> Result { get; set; }
    }
}
