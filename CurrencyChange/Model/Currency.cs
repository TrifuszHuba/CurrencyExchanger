using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyChange.ViewModel;
using CurrencyChange.ViewModel.Commands;
using CurrencyChange.ViewModel.Helpers;

namespace CurrencyChange.Model
{
    public class Currency
    {
        public string Abbreviation { get; set; }
        public string FullName { get; set; }
        public float RelativeValue { get; set; }
        public ObservableCollection<Currency> AvailableCurrencies { get; set; }
        public DeleteCurrencyCommand DeleteCurrencyCommand { get { return vm.DeleteCurrencyCommand; } }
        readonly CurrencyChangeVM? vm;

        public int IndexInList { get
            {
                Currency thisCurrency = AvailableCurrencies.Where(c => Abbreviation == c.Abbreviation).First();
                int asd = AvailableCurrencies.IndexOf(thisCurrency);
                return AvailableCurrencies.IndexOf(thisCurrency);
            }
            set 
            {
                Abbreviation = AvailableCurrencies[value].Abbreviation;
                CurrencyChangeHelper.SetConversionRates(vm.currencyConverter);
                vm.OnPropertyChanged("Currencies");
                vm.OnPropertyChanged("Amount");
            }

        }

        public Currency(string abbreviation, string fullName, CurrencyChangeVM vm)
        {
            Abbreviation = abbreviation;
            FullName = fullName;
            RelativeValue = 0f;
            AvailableCurrencies = vm.AvailableCurrencies;
            this.vm = vm;
        }
        public Currency(string abbreviation, string fullName)
        {
            Abbreviation = abbreviation;
            FullName = fullName;
            RelativeValue = 0f;
        }

        public override string ToString()
        {
            return Abbreviation;
        }
    }
}
