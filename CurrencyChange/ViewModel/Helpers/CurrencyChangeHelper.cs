using CurrencyChange.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CurrencyChange.ViewModel.Helpers
{
    public static class CurrencyChangeHelper
    {
        public static async Task<List<Currency>> GetCurrencies()
        {
            string url = "https://currency-converter-pro1.p.rapidapi.com/currencies";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "X-RapidAPI-Key", "8448ffc4f7mshd200cf19633f440p10409djsn3eb2af177422" },
                    { "X-RapidAPI-Host", "currency-converter-pro1.p.rapidapi.com" },
                },
            };

            List<Currency>? currencies = new List<Currency>();
            using (HttpClient client = new HttpClient())
            {
                var response = client.SendAsync(request).Result;
                string json = await response.Content.ReadAsStringAsync();
                GetCurrenciesResponse apiResponse = JsonConvert.DeserializeObject<GetCurrenciesResponse>(json);
                foreach (var keyValuePair in apiResponse.Result)
                {
                    currencies.Add(new Currency(keyValuePair.Key, keyValuePair.Value));
                }
            }
            return currencies;
        }

        public static async void SetConversionRates(CurrencyConverter currencyConverter)
        {
            string url = $"https://currency-converter-pro1.p.rapidapi.com/latest-rates?base={currencyConverter.Base.Abbreviation}&currencies={currencyConverter.CurrencyList[0].Abbreviation}";
            for (int i = 1; i < currencyConverter.CurrencyList.Count; i++)
            {
                url += $"%2C{currencyConverter.CurrencyList[i].Abbreviation}";
            }

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "X-RapidAPI-Key", "8448ffc4f7mshd200cf19633f440p10409djsn3eb2af177422" },
                    { "X-RapidAPI-Host", "currency-converter-pro1.p.rapidapi.com" },
                },
            };

            using (HttpClient client = new HttpClient())
            {
                var response = client.SendAsync(request).Result;
                string json = await response.Content.ReadAsStringAsync();
                GetConversionRatesResponse apiResponse = JsonConvert.DeserializeObject<GetConversionRatesResponse>(json);
                foreach (var keyValuePair in apiResponse.Result)
                {
                    string amount = keyValuePair.Value.Replace('.', ',');
                    currencyConverter.CurrencyList.Find(c => c.Abbreviation == keyValuePair.Key).RelativeValue = float.Parse(amount);
                }
                await Console.Out.WriteLineAsync();
            }
        }
    }
}
