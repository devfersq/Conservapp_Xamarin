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

                            NombreCEntry = JsonResult_.nOmbre;
                            DireccionEntry = JsonResult_.dIreccion;
                            referenciaEntry = JsonResult_.rEferencias;
                            tipodePropiedadEntry = JsonResult_.tIpodePropiedad;
                            responsabledelinmuebleEntry = JsonResult_.rEsponsabledelInmueble;
                            zMHEntry = JsonResult_.ZMH;
                            pCHEntry = JsonResult_.PCH;
                            monumentohistoricoEntry = JsonResult_.mOnumentohistorico;
                            referenciajuridicaEntry = JsonResult_.rEferenciajuridica;
                            ndenivelesEntry = JsonResult_.nUmerodeniveles;
                            atotalEntry = JsonResult_.aReatotal;
                            aredeconstruccionEntry = JsonResult_.aReadeconstruccion;
                            ndeaccesosEntry = JsonResult_.nUmerodeaccesos;
                            usooriginalEntry = JsonResult_.uSoriginal;
                            usoactualEntry = JsonResult_.uSoactual;
                            habitadoEntry = JsonResult_.hAbitado;
                            estiloarqEntry = JsonResult_.eStiloarquitectonico;
                            adeconstruccionEntry = JsonResult_.aNodeconstruccion;//
                            etapasconsEntry = JsonResult_.eTapasconstructivas;
                            intervencionesrEntry = JsonResult_.iNtervencionesregistradas;
                            principalesdeteriorosEntry = JsonResult_.pRincipalesdeterioros;
                            alteracionesrelevantesEntry = JsonResult_.aLteracionesrelevantes;
                            estadodeconservacionEntry = JsonResult_.eStadodeconservacion;//
                            criteriosdevrEntry = JsonResult_.cRiteriosdevalorenriesgo;
                            gradodevulnerabilidadEntry = JsonResult_.gRadodevulnerabilidad;
                            gradoderesilienciaEntry = JsonResult_.gRadoderesiliencia;
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

        #region Get & set
        private string _NombreCEntry;
        public string NombreCEntry
        {
            get { return _NombreCEntry; }
            set { SetProperty(ref _NombreCEntry, value); }
        }
        private string _DireccionEntry;
        public string DireccionEntry
        {
            get { return _DireccionEntry; }
            set { SetProperty(ref _DireccionEntry, value); }
        }

        private string _referenciaEntry;
        public string referenciaEntry
        {
            get { return _referenciaEntry; }
            set { SetProperty(ref _referenciaEntry, value); }
        }
        private string _tipodePropiedadEntry;
        public string tipodePropiedadEntry
        {
            get { return _tipodePropiedadEntry; }
            set { SetProperty(ref _tipodePropiedadEntry, value); }
        }
        private string _responsabledelinmuebleEntry;
        public string responsabledelinmuebleEntry
        {
            get { return _responsabledelinmuebleEntry; }
            set { SetProperty(ref _responsabledelinmuebleEntry, value); }
        }
        private string _zMHEntry;
        public string zMHEntry
        {
            get { return _zMHEntry; }
            set { SetProperty(ref _zMHEntry, value); }
        }
        private string _pCHEntry;
        public string pCHEntry
        {
            get { return _pCHEntry; }
            set { SetProperty(ref _pCHEntry, value); }
        }
        private string _monumentohistoricoEntry;
        public string monumentohistoricoEntry
        {
            get { return _monumentohistoricoEntry; }
            set { SetProperty(ref _monumentohistoricoEntry, value); }
        }
        private string _referenciajuridicaEntry;
        public string referenciajuridicaEntry
        {
            get { return _referenciajuridicaEntry; }
            set { SetProperty(ref _referenciajuridicaEntry, value); }
        }
        private string _ndenivelesEntry;
        public string ndenivelesEntry
        {
            get { return _ndenivelesEntry; }
            set { SetProperty(ref _ndenivelesEntry, value); }
        }
        private string _atotalEntry;
        public string atotalEntry
        {
            get { return _atotalEntry; }
            set { SetProperty(ref _atotalEntry, value); }
        }
        private string _aredeconstruccionEntry;
        public string aredeconstruccionEntry
        {
            get { return _aredeconstruccionEntry; }
            set { SetProperty(ref _aredeconstruccionEntry, value); }
        }
        private string _adeconstruccionEntry;
        public string adeconstruccionEntry
        {
            get { return _adeconstruccionEntry; }
            set { SetProperty(ref _adeconstruccionEntry, value); }
        }
        private string _ndeaccesosEntry;
        public string ndeaccesosEntry
        {
            get { return _ndeaccesosEntry; }
            set { SetProperty(ref _ndeaccesosEntry, value); }
        }
        private string _usooriginalEntry;
        public string usooriginalEntry
        {
            get { return _usooriginalEntry; }
            set { SetProperty(ref _usooriginalEntry, value); }
        }
        private string _usoactualEntry;
        public string usoactualEntry
        {
            get { return _usoactualEntry; }
            set { SetProperty(ref _usoactualEntry, value); }
        }
        private string _habitadoEntry;
        public string habitadoEntry
        {
            get { return _habitadoEntry; }
            set { SetProperty(ref _habitadoEntry, value); }
        }
        private string _estiloarqEntry;
        public string estiloarqEntry
        {
            get { return _estiloarqEntry; }
            set { SetProperty(ref _estiloarqEntry, value); }
        }
        private string _etapasconsEntry;
        public string etapasconsEntry
        {
            get { return _etapasconsEntry; }
            set { SetProperty(ref _etapasconsEntry, value); }
        }
        private string _intervencionesrEntry;
        public string intervencionesrEntry
        {
            get { return _intervencionesrEntry; }
            set { SetProperty(ref _intervencionesrEntry, value); }
        } 
        private string _principalesdeteriorosEntry;
        public string principalesdeteriorosEntry
        {
            get { return _principalesdeteriorosEntry; }
            set { SetProperty(ref _principalesdeteriorosEntry, value); }
        }
        private string _alteracionesrelevantesEntry;
        public string alteracionesrelevantesEntry
        {
            get { return _alteracionesrelevantesEntry; }
            set { SetProperty(ref _alteracionesrelevantesEntry, value); }
        }
        private string _estadodeconservacionEntry;
        public string estadodeconservacionEntry
        {
            get { return _estadodeconservacionEntry; }
            set { SetProperty(ref _estadodeconservacionEntry, value); }
        }  
        private string _criteriosdevrEntry;
        public string criteriosdevrEntry
        {
            get { return _criteriosdevrEntry; }
            set { SetProperty(ref _criteriosdevrEntry, value); }
        } 
        private string _gradodevulnerabilidadEntry;
        public string gradodevulnerabilidadEntry
        {
            get { return _gradodevulnerabilidadEntry; }
            set { SetProperty(ref _gradodevulnerabilidadEntry, value); }
        } 
        private string _gradoderesilienciaEntry;
        public string gradoderesilienciaEntry
        {
            get { return _gradoderesilienciaEntry; }
            set { SetProperty(ref _gradoderesilienciaEntry, value); }
        }

        #endregion

    }
}