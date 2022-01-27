using Conservapp.Render.Splash;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Conservapp.Views.Splash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreenView : ContentPage
    {
        public SplashScreenView()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            try
            {
                base.OnAppearing();

                await AnimateR.BallAnimate(this.icosplash, 50, 10, 5);
                await Navigation.PushModalAsync(new LoginPage());

            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
        }
    }
}