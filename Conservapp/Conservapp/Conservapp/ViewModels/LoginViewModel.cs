using Acr.UserDialogs;
using Conservapp.Controls;
using Conservapp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace Conservapp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command IngresarQRCommand { get; set; }
        public Command IngresarCommand { get; set; }
      
        public LoginViewModel()
        {
            try
            {
                this.IngresarQRCommand = new Command(IngresarQRCommandClicked);
                this.IngresarCommand = new Command(IngresarCommandClicked);
            }catch(Exception ex)
            {
                var error = ex.ToString();
            }
            
        }
        public async void IngresarQRCommandClicked()
        {
            try
            {
                #region
                var options = new MobileBarcodeScanningOptions();
                options.PossibleFormats = new List<BarcodeFormat>
            {
                BarcodeFormat.QR_CODE,
                BarcodeFormat.CODE_128,
                BarcodeFormat.EAN_13
            };
                var page = new ZXingScannerPage(options) { Title = "Escanee el código de barra." };
                var closeItem = new ToolbarItem { Text = "Cancelar" };
                closeItem.Clicked += (object sender, EventArgs e) =>
                {
                    page.IsScanning = false;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage.Navigation.PopModalAsync();
                    });
                };
                page.ToolbarItems.Add(closeItem);
                page.OnScanResult += (result) =>
                {
                    page.IsScanning = false;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                      await Application.Current.MainPage.Navigation.PopModalAsync();
                        if (string.IsNullOrEmpty(result.Text))
                        {
                           await Application.Current.MainPage.DisplayAlert("ConservAPP", "No se ha escaneado ningún código válido.", "Aceptar");
                        }
                        else
                        {
                            var aux_ = ($"{result}");
                            var ObjJson_ = string.Concat(aux_);
                            var JsonResult_ = JsonConvert.DeserializeObject<LoginModel>(ObjJson_);
                            var uSer_Entry = JsonResult_.Email;
                            var pAss_Entry = JsonResult_.Passw;
                            if (uSer_Entry.Equals("cegirpuebla@gmail.com") && pAss_Entry.Equals("1234567") || uSer_Entry.Equals("maria.lara@gmail.com") && pAss_Entry.Equals("1234567") || uSer_Entry.Equals("alejandro.benitez@gmail.com") && pAss_Entry.Equals("1234567") ||
                            uSer_Entry.Equals("moises.morales@gmail.com") && pAss_Entry.Equals("1234567") || uSer_Entry.Equals("vicente.martinez@gmail.com") && pAss_Entry.Equals("1234567") || uSer_Entry.Equals("manuel.villarruel@gmail.com") && pAss_Entry.Equals("1234567"))
                            {
                                //App.Current.MainPage = new AppShell();
                                UserDialogs.Instance.ShowLoading("Validando registro ...");
                                Userlogged.UserName = uSer_Entry;
                                App.Current.MainPage = new AppShell();
                                UserDialogs.Instance.HideLoading();
                            }
                                    else
                                    {
                                  await  Application.Current.MainPage.DisplayAlert("ConservApp", "Usuario no encontrado...", "Aceptar");
                            }
                        }
                    });
                };
                _ = Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(page)
                {
                    BarTextColor = Color.White,
                    BarBackgroundColor = Color.Black
                }, true);
                #endregion


            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                UserDialogs.Instance.HideLoading();
            }

        }
        public async void IngresarCommandClicked()
        {
            try
            {
                App.Current.MainPage = new AppShell();
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

                        if (uSer_Entry.Equals("cegirpuebla@gmail.com") && pAss_Entry.Equals("1234567") || uSer_Entry.Equals("maria.lara@gmail.com") && pAss_Entry.Equals("1234567") || uSer_Entry.Equals("alejandro.benitez@gmail.com") && pAss_Entry.Equals("1234567") ||
                            uSer_Entry.Equals("moises.morales@gmail.com") && pAss_Entry.Equals("1234567") || uSer_Entry.Equals("vicente.martinez@gmail.com") && pAss_Entry.Equals("1234567") || uSer_Entry.Equals("manuel.villarruel@gmail.com") && pAss_Entry.Equals("1234567"))
                        {
                            UserDialogs.Instance.ShowLoading("Validando registro ...");
                            Userlogged.UserName = uSer_Entry;
                            App.Current.MainPage = new AppShell();
                            UserDialogs.Instance.HideLoading();
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("ConservApp", "Usuario no encontrado...", "Aceptar");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                UserDialogs.Instance.HideLoading();
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
