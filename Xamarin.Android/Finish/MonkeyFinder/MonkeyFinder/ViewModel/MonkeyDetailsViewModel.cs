using MonkeyFinder.Model;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MonkeyFinder.ViewModel
{
    public class MonkeyDetailsViewModel
    {
        public MonkeyDetailsViewModel()
        {

        }

        public MonkeyDetailsViewModel(Monkey monkey)
            : this()
        {
            Monkey = monkey;
        }
        Monkey monkey;
        public Monkey Monkey
        {
            get => monkey;
            set
            {
                if (monkey == value)
                    return;

                monkey = value;
            }
        }

        public async Task OpenMapAsync()
        {
            try
            {
                await Map.OpenAsync(Monkey.Latitude, Monkey.Longitude);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to launch maps: {ex.Message}");
            }
        }
    }
}
