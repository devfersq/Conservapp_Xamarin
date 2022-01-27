using System;
using Xamarin.Forms;

namespace Conservapp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command IngresarCommand { get; set; }
        public LoginViewModel()
        {
            this.IngresarCommand = new Command(IngresarCommandClicked);
        }

        public async void IngresarCommandClicked()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(uSer_Entry))
                {
                    await Application.Current.MainPage.DisplayAlert("ConservApp", "El campo usuario, es obligatorio.", "Aceptar");
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(pAss_Entry))
                    {
                        await Application.Current.MainPage.DisplayAlert("ConservApp", "El campo contraseña, es obligatorio.", "Aceptar");
                    }
                    else
                    {
                       // await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                        App.Current.MainPage = new AppShell();
                    }
                }

            }
            catch (Exception ex)
            {
                var error = ex.ToString();
      
            }
        }
        #region Validations Entry
        private string _pAss_Entry;
        public string pAss_Entry
        {
            get { return _pAss_Entry; }
            set { SetProperty(ref _pAss_Entry, value); }
        }
        private string _uSer_Entry;
        public string uSer_Entry
        {
            get { return _uSer_Entry; }
            set { SetProperty(ref _uSer_Entry, value); }
        }

        #endregion
    }
}
