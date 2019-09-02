using Com.Jcvegan.CountriesApp.Models;
using Com.Jcvegan.CountriesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Com.Jcvegan.CountriesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryInfoView : ContentPage
    {
        private readonly CountryModel _country;
        public CountryInfoView(CountryModel country)
        {
            InitializeComponent();
            _country = country;
            Title = country.Name;
            BindingContext = ServiceLocator.Resolve<CountryInfoViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.InitializeAsync(_country.Alpha3Code);
        }

        private CountryInfoViewModel ViewModel => (CountryInfoViewModel) BindingContext;
    }
}