using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyChange.Model;
using CurrencyChange.ViewModel.Commands;
using CurrencyChange.ViewModel.Helpers;

namespace CurrencyChange.ViewModel
{
    public class CurrencyChangeVM : INotifyPropertyChanged
    {
        ObservableCollection<Currency> AvailableCurrencies { get; set; }
        CurrencyConverter currencyConverter = new CurrencyConverter();
        public QueryCurrenciesCommand? QueryCurrenciesCommand { get; set; }
        public string Amount 
        {
            get { return currencyConverter.amount.ToString(); }
            set 
            { 
                int.TryParse(value, out currencyConverter.amount);
                CurrencyChangeHelper.SetConversionRates(currencyConverter);
                OnPropertyChanged("Amount");
            }
        }

        public CurrencyChangeVM()
        {
            AvailableCurrencies = new ObservableCollection<Currency>();
            currencyConverter = new CurrencyConverter();
            List<Currency> currencies = CurrencyChangeHelper.GetCurrencies().GetAwaiter().GetResult();
            AvailableCurrencies = new ObservableCollection<Currency>(currencies);
            QueryCurrenciesCommand = new QueryCurrenciesCommand(this);
        }

        public async void QueryCurrencies()
        {
            List<Currency> currencies = await CurrencyChangeHelper.GetCurrencies();
            AvailableCurrencies = new ObservableCollection<Currency>(currencies);
        }
        private void OnPropertyChanged(string v)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
