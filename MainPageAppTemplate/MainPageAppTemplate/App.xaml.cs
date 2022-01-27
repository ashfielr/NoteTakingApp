using NoteTakingApp.Services;
using NoteTakingApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteTakingApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new MainPage());   // Serving MainPage as root page for navigation page
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
