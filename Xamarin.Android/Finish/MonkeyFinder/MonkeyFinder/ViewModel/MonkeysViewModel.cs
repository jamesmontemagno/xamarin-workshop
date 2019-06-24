using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

using System.Linq;
using MonkeyFinder.Model;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Collections.Generic;

namespace MonkeyFinder.ViewModel
{
    public class MonkeysViewModel
    {
        HttpClient httpClient;
        HttpClient Client => httpClient ?? (httpClient = new HttpClient());

        public ObservableCollection<Monkey> Monkeys { get; }
        public MonkeysViewModel()
        {
            Monkeys = new ObservableCollection<Monkey>();

        }

        public async Task GetMonkeysAsync()
        {
            try
            {
                var json = await Client.GetStringAsync("https://montemagno.com/monkeys.json");
                var monkeys =  Monkey.FromJson(json);

                Monkeys.Clear();
                foreach (var monkey in monkeys)
                    Monkeys.Add(monkey);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            }
            finally
            {
            }
        }
    }
}
