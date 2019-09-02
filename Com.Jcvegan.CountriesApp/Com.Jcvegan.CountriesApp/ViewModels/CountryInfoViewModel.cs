using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Com.Jcvegan.CountriesApp.Annotations;
using Com.Jcvegan.CountriesApp.Models;
using Com.Jcvegan.CountriesApp.Services;

namespace Com.Jcvegan.CountriesApp.ViewModels
{
    public class CountryInfoViewModel : INotifyPropertyChanged
    {
        private readonly ICountryService _countryService;

        private bool _isLoading = false;
        private CountryFullModel _model = null;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            } 
        }

        public CountryFullModel Country
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged("Country");
            }
        }

        public CountryInfoViewModel(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task InitializeAsync(string countryCode)
        {
            IsLoading = true;
            var country = _countryService.GetCountryInfoAsync(countryCode);
            Country = await country;
            IsLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}