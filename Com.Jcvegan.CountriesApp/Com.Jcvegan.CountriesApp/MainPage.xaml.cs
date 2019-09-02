using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jcvegan.CountriesApp.Models;
using Com.Jcvegan.CountriesApp.ViewModels;
using Xamarin.Forms;

namespace Com.Jcvegan.CountriesApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var viewModel = this.BindingContext as MainViewModel;
            viewModel.Initialize();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedCountry = (CountryModel) e.Item;
            Navigation.PushAsync(new CountryInfoView(selectedCountry),true);
        }
    }
}
