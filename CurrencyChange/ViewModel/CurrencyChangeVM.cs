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
        public ObservableCollection<Currency> AvailableCurrencies { get; set; }
        public CurrencyConverter currencyConverter;
        public QueryCurrenciesCommand? QueryCurrenciesCommand { get; set; }
        public AddCurrencyCommand? AddCurrencyCommand { get; set; }
        public DeleteCurrencyCommand? DeleteCurrencyCommand { get; set; }
        public string Amount 
        {
            get { return currencyConverter.amount.ToString(); }
            set 
            { 
                int.TryParse(value, out currencyConverter.amount);
                CurrencyChangeHelper.SetConversionRates(currencyConverter);
                OnPropertyChanged("Amount");
                OnPropertyChanged("Currencies");
            }
        }

        public int BaseCurrencyIndex
        {
            get
            {
                return currencyConverter.Base.IndexInList;
            }
            set
            {
                currencyConverter.Base.IndexInList = value;
            }
        }

        public ObservableCollection<Currency> Currencies { get
            {
                return new ObservableCollection<Currency>(currencyConverter.CurrencyList);
            }
            set
            {
                currencyConverter.CurrencyList = value.ToList();
            }
        }

        public CurrencyChangeVM()
        {
            DeleteCurrencyCommand = new DeleteCurrencyCommand(this);
            AvailableCurrencies = new ObservableCollection<Currency>();
            List<Currency> currencies = CurrencyChangeHelper.GetCurrencies().GetAwaiter().GetResult();
            AvailableCurrencies = new ObservableCollection<Currency>(currencies);
            currencyConverter = new CurrencyConverter(this);
            QueryCurrenciesCommand = new QueryCurrenciesCommand(this);
            AddCurrencyCommand = new AddCurrencyCommand(this);
        }

        public async void QueryCurrencies()
        {
            List<Currency> currencies = await CurrencyChangeHelper.GetCurrencies();
            AvailableCurrencies = new ObservableCollection<Currency>(currencies);
        }

        public async void AddCurrency()
        {
            currencyConverter.CurrencyList.Add(new Currency("EUR", "Euro", this));
            await CurrencyChangeHelper.SetConversionRates(currencyConverter);
            OnPropertyChanged("Currencies");
            OnPropertyChanged("RelativeValue");
        }
        public void DeleteCurrency(string abbreviation)
        {
            currencyConverter.CurrencyList.Remove(currencyConverter.CurrencyList.Find(c => abbreviation == c.Abbreviation));
            OnPropertyChanged("Currencies");
        }
        public void OnPropertyChanged(string v)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
