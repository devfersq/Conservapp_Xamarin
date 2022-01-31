using Conservapp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace Conservapp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        
            public Command OpenQrCommand { get; set; }
        public AboutViewModel()
        {
            try
            {
                this.OpenQrCommand = new Command(IngresarQRCommandClicked);
            }catch(Exception ex)
            {
                var error = ex.ToString();
            }
            Title = "Bienvenido";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
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
                    //ResultScan = result.ToString();
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage.Navigation.PopModalAsync();
                        if (string.IsNullOrEmpty(result.Text))
                        {
                            Application.Current.MainPage.DisplayAlert("CSIndustrial", "No se ha escaneado ningún código válido.", "Aceptar");
                        }
                        else
                        {
                            var aux_ = ($"{result}");
                            var ObjJson_ = string.Concat(aux_);
                            var JsonResult_ = JsonConvert.DeserializeObject<FirstFormModel>(ObjJson_);

                        }
                    });
                };
                _ = Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(page)
                {
                    BarTextColor = Color.White,
                    BarBackgroundColor = Color.CadetBlue
                }, true);
                #endregion


            }
            catch (Exception ex)
            {
                var error = ex.ToString();

            }
        }

    }
}