using System;
using Com.Jcvegan.CountriesApp.Services;
using Com.Jcvegan.CountriesApp.Services._Common;
using Com.Jcvegan.CountriesApp.ViewModels;
using Unity;
using Unity.Lifetime;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Com.Jcvegan.CountriesApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ServiceLocator.Initialize(container =>
                {
                    container.RegisterType<IResponseTypeFormatter, JsonResponseTypeFormatter>(
                        new ContainerControlledLifetimeManager());
                    container.RegisterType<ICountryService, CountryService>();
                    container.RegisterType<MainViewModel>();
                    container.RegisterType<CountryInfoViewModel>();
                });
            MainPage = new NavigationPage(new MainPage());
            MainPage.BindingContext = ServiceLocator.Resolve<MainViewModel>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
