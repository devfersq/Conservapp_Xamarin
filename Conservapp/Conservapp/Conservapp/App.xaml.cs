using Conservapp.Views.Splash;
using System;
using Xamarin.Forms;

namespace Conservapp
{
    public partial class App : Application
    {

        public App()
        {
            try
            {
                InitializeComponent();
                MainPage = new SplashScreenView();
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }

            // DependencyService.Register<MockDataStore>();
            //  MainPage = new AppShell();
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
