using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Com.Jcvegan.CountriesApp.Annotations;
using Com.Jcvegan.CountriesApp.Models;
using Com.Jcvegan.CountriesApp.Services;

namespace Com.Jcvegan.CountriesApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICountryService _countryService;

        private IEnumerable<CountryModel> _countries;

        public IEnumerable<CountryModel> Countries
        {
            get => _countries;
            set
            {
                _countries = value;
                OnPropertyChanged("Countries");
            }
        }

        public MainViewModel(ICountryService countryService)
        {
            _countryService = countryService;
            //Initialize();
        }

        public async Task Initialize()
        {
            Countries = await _countryService.GetCountriesAsync(null);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}