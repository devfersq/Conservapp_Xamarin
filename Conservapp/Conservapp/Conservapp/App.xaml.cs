using Conservapp.Views.Splash;
using Xamarin.Forms;

namespace Conservapp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new SplashScreenView();
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
