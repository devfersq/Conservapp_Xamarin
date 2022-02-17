using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Conservapp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        
             public Command sEndFormsCommand { get; set; }
             public Command lOadImageCommand { get; set; }
        public ItemsViewModel()
        {
            try
            {
                Title = "Formulario";
                this.sEndFormsCommand = new Command(sEndFormsCommandClicked);
                this.lOadImageCommand = new Command(lOadImageCommandClicked);
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
        }
        public async Task<Image> RetriveImageFromLocation(string location)
        {
            Image image = new Image();
            var memoryStream = new MemoryStream();

            using (var source = System.IO.File.OpenRead(location))
            {
                await source.CopyToAsync(memoryStream);
            }

            image.Source = ImageSource.FromStream(() => memoryStream);
            return image;
        }
        public async void sEndFormsCommandClicked()
        {
            try
            {
                //var imgSourceV = ImageSource.FromUri(new Uri(file_path));
                //var byteArray = new WebClient().DownloadData(file_path);
                //var image = new Image { Source = file_path };
                //var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                //{
                //    PhotoSize = PhotoSize.Small
                //});

               // var xxxx = new UIImageView(UIImage.FromBundle("face-template.png"));
                //var xxxx = DependencyService.Get <IDependency().RetriveImageFromLocation(file_path);
               // var xxx = ImageSource.FromStream(() => typeof(App).Assembly.GetManifestResourceStream(file_path));
                await Share.RequestAsync(new ShareTextRequest
                {

                    Subject = "[ConservApp] EVALUACIÓN RAPIDA DE DAÑOS",
                    Text = "ConservApp",
                    Title = "[ConservApp] EVALUACIÓN RAPIDA DE DAÑOS",
                    Uri = "Contingencia:"+ ContingenciaEntry+ "\n" + "Fecha:"+ FechaEntry + "\n" + "Hora:" + HoraEntry + "\n" 
                         + "Nombre del evaluador:" + NombreevaluadorEntry + "\n" + "Teléfono:" + TelefonoEntry + "\n" + "Acompañante en la visita:" + AcompananteVisitaEntry + "\n"+ "EVALUACIÓN" + "\n" + "Condiciones preexistentes" + "\n"
                         + "Uso actual:" + UsoActualEntry + "\n" + "Estado de conservación:" + "\n" + "Muy bueno:" + IsCheckedMB + "\n" + "Bueno:" + IsCheckedB + "\n" + "Regular:" + IsCheckedR + "\n"
                         + "Malo:" + IsCheckedM + "\n" + "Critico:" + IsCheckedC + "\n" + "Falta de mantenimiento:" + "\n" + "Si:" + IsCheckedFDMS + "\n" + "No:" + IsCheckedFDMN + "\n" + "Levantamientos actualizados:" + "\n" + "Si:"+ IsCheckedLAS + "\n"
                         + "No:" + IsCheckedLAN + "\n" + "Conjunto en general:" + "\n" + "Colapso total:" + IsCheckedCT + "\n" + "Colapso parcial:" + IsCheckedCP + "\n" 
                         + "Inclinación del edificio o de uno de sus niveles:" + IsCheckedIDEODUDSN + "\n" + "Fallo o asentamiento de la cimentación:" + IsCheckedFOADLC + "\n"
                         + "Elementos estructurales" + "\n" + "Sistemas constructivos:" + sistemasConstructivosEntry + "\n"+ "Cubiertas:" + "\n" + "Losas:" + LosasEntry + "\n"
                         + "Cupulas:" + CupulasEntry + "\n" + "Bóvedas:" + BovedasEntry + "\n" + "Techumbres:" + TechumbresEntry + "\n" + "Elementos verticales:" + "\n"
                         + "Mampostería piedra:" + MateriapiedraEntry + "\n" + "Mampostería tabique:" + MtabiqueEntry + "\n" + "Muros de concreto:" + MconcretoEntry + "\n" + "Columnas:"+ ColumnasEntry + "\n"
                         + "Pilastras:" + PilastrasEntry + "\n" + "Contrafuertes:" + ContrafuertesEntry + "\n" + "Elementos horizontales:" + "\n" + "Arcos:" + ArcosEntry + "\n"
                         + "Vigas:" + VigasEntry + "\n" + "Trabes:" + TrabesEntry + "\n" + "Otros elementos:" + "\n" + "Torres:" + TorresEntry + "\n"
                         + "Espadañas:" + EspadanasEntry + "\n" + "Elementos no estructurales:" + "\n" + "Acabados y recubrimientos:"+ ARecubrimientosEntry + "\n" + "Puertas y ventanas:" + PVentasEntry + "\n"
                         + "Ornamentos:" + OrnamentosEntry + "\n" + "Candelabros:" + CandelabrosEntry + "\n" + "Plafones o cielos rasos:" + PCielosrasosEntry + "\n"
                         + "Retablos:" + RetablosEntry + "\n"// + xxxx
                    //ImageSource.FromStream(() => new MemoryStream(byteArray))+ image+ xxx
                    //ImageSource.FromStream(() => typeof(App).Assembly.GetManifestResourceStream("background.png"))  //"Candelabros:" + CandelabrosEntry + "\n" + "Plafones o cielos rasos:" + PCielosrasosEntry + "\n"

                });
            }
            catch(Exception ex)
            {
                var error = ex.ToString();
            }
        }

        public string file_path;
        public async void lOadImageCommandClicked()
        {
            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Esto no es compatible con su dispositivo.", "OK");
                    return;
                }
                else
                {
                   
                    var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                    {
                        PhotoSize = PhotoSize.Small
                    });
                    if (file != null)
                    {
                        BimageView = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            file_path = file.Path;
                            file.Dispose();
                            return stream;
                            
                        });
                    }

                    LabelURLPath = file_path;
                }
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
        }
        #region
        private ImageSource imageSource;
        public ImageSource BimageView
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged("BimageView");
            }

        }

        private string _LabelURLPath;
        public string LabelURLPath
        {
            get { return _LabelURLPath; }
            set
            {
                _LabelURLPath = value;
                OnPropertyChanged(nameof(LabelURLPath)); 
            }
        }
        private string _ContingenciaEntry;
        public string ContingenciaEntry
        {
            get { return _ContingenciaEntry; }
            set { SetProperty(ref _ContingenciaEntry, value); }
        }
        private string _FechaEntry;
        public string FechaEntry
        {
            get { return _FechaEntry; }
            set { SetProperty(ref _FechaEntry, value); }
        }
        private string _HoraEntry;
        public string HoraEntry
        {
            get { return _HoraEntry; }
            set { SetProperty(ref _HoraEntry, value); }
        }
        private string _NombreevaluadorEntry;
        public string NombreevaluadorEntry
        {
            get { return _NombreevaluadorEntry; }
            set { SetProperty(ref _NombreevaluadorEntry, value); }
        }
        private string _TelefonoEntry;
        public string TelefonoEntry
        {
            get { return _TelefonoEntry; }
            set { SetProperty(ref _TelefonoEntry, value); }
        }
        private string _AcompananteVisitaEntry;
        public string AcompananteVisitaEntry
        {
            get { return _AcompananteVisitaEntry; }
            set { SetProperty(ref _AcompananteVisitaEntry, value); }
        }
        private string _UsoActualEntry;
        public string UsoActualEntry
        {
            get { return _UsoActualEntry; }
            set { SetProperty(ref _UsoActualEntry, value); }
        }
        #region CheckBox
        public bool _IsCheckedMB = false;
        public bool IsCheckedMB
        {
            get
            {
                return _IsCheckedMB;
            }
            set
            {
                _IsCheckedMB = value;
                this.OnPropertyChanged("IsCheckedMB");
            }
        }
        public bool _IsCheckedB = false;
        public bool IsCheckedB
        {
            get
            {
                return _IsCheckedB;
            }
            set
            {
                _IsCheckedB = value;
                this.OnPropertyChanged("IsCheckedB");
            }
        }
        public bool _IsCheckedR = false;
        public bool IsCheckedR
        {
            get
            {
                return _IsCheckedR;
            }
            set
            {
                _IsCheckedR = value;
                this.OnPropertyChanged("IsCheckedR");
            }
        }
        public bool _IsCheckedM = false;
        public bool IsCheckedM
        {
            get
            {
                return _IsCheckedM;
            }
            set
            {
                _IsCheckedM = value;
                this.OnPropertyChanged("IsCheckedM");
            }
        }
        public bool _IsCheckedC = false;
        public bool IsCheckedC
        {
            get
            {
                return _IsCheckedC;
            }
            set
            {
                _IsCheckedC = value;
                this.OnPropertyChanged("IsCheckedC");
            }
        }
        public bool _IsCheckedFDMS = false;
        public bool IsCheckedFDMS
        {
            get
            {
                return _IsCheckedFDMS;
            }
            set
            {
                _IsCheckedFDMS = value;
                this.OnPropertyChanged("IsCheckedFDMS");
            }
        }
        public bool _IsCheckedFDMN = false;
        public bool IsCheckedFDMN
        {
            get
            {
                return _IsCheckedFDMN;
            }
            set
            {
                _IsCheckedFDMN = value;
                this.OnPropertyChanged("IsCheckedFDMN");
            }
        }
        public bool _IsCheckedLAS = false;
        public bool IsCheckedLAS
        {
            get
            {
                return _IsCheckedLAS;
            }
            set
            {
                _IsCheckedLAS = value;
                this.OnPropertyChanged("IsCheckedLAS");
            }
        }
        public bool _IsCheckedLAN = false;
        public bool IsCheckedLAN
        {
            get
            {
                return _IsCheckedLAN;
            }
            set
            {
                _IsCheckedLAN = value;
                this.OnPropertyChanged("IsCheckedLAN");
            }
        }
        public bool _IsCheckedCT = false;
        public bool IsCheckedCT
        {
            get
            {
                return _IsCheckedCT;
            }
            set
            {
                _IsCheckedCT = value;
                this.OnPropertyChanged("IsCheckedCT");
            }
        }
        public bool _IsCheckedCP = false;
        public bool IsCheckedCP
        {
            get
            {
                return _IsCheckedCP;
            }
            set
            {
                _IsCheckedCP = value;
                this.OnPropertyChanged("IsCheckedCP");
            }
        }
        public bool _IsCheckedIDEODUDSN = false;
        public bool IsCheckedIDEODUDSN
        {
            get
            {
                return _IsCheckedIDEODUDSN;
            }
            set
            {
                _IsCheckedIDEODUDSN = value;
                this.OnPropertyChanged("IsCheckedIDEODUDSN");
            }
        }
        public bool _IsCheckedFOADLC = false;
        public bool IsCheckedFOADLC
        {
            get
            {
                return _IsCheckedFOADLC;
            }
            set
            {
                _IsCheckedFOADLC = value;
                this.OnPropertyChanged("IsCheckedFOADLC");
            }
        }
        #endregion
        
        private string _sistemasConstructivosEntry;
        public string sistemasConstructivosEntry
        {
            get { return _sistemasConstructivosEntry; }
            set { SetProperty(ref _sistemasConstructivosEntry, value); }
        }
        private string _LosasEntry;
        public string LosasEntry
        {
            get { return _LosasEntry; }
            set { SetProperty(ref _LosasEntry, value); }
        }
        private string _CupulasEntry;
        public string CupulasEntry
        {
            get { return _CupulasEntry; }
            set { SetProperty(ref _CupulasEntry, value); }
        }
        private string _BovedasEntry;
        public string BovedasEntry
        {
            get { return _BovedasEntry; }
            set { SetProperty(ref _BovedasEntry, value); }
        }
        private string _TechumbresEntry;
        public string TechumbresEntry
        {
            get { return _TechumbresEntry; }
            set { SetProperty(ref _TechumbresEntry, value); }
        }
        private string _MateriapiedraEntry;
        public string MateriapiedraEntry
        {
            get { return _MateriapiedraEntry; }
            set { SetProperty(ref _MateriapiedraEntry, value); }
        }
        private string _MtabiqueEntry;
        public string MtabiqueEntry
        {
            get { return _MtabiqueEntry; }
            set { SetProperty(ref _MtabiqueEntry, value); }
        }
        private string _MconcretoEntry;
        public string MconcretoEntry
        {
            get { return _MconcretoEntry; }
            set { SetProperty(ref _MconcretoEntry, value); }
        }
        private string _ColumnasEntry;
        public string ColumnasEntry
        {
            get { return _ColumnasEntry; }
            set { SetProperty(ref _ColumnasEntry, value); }
        }
        private string _PilastrasEntry;
        public string PilastrasEntry
        {
            get { return _PilastrasEntry; }
            set { SetProperty(ref _PilastrasEntry, value); }
        }
        private string _ContrafuertesEntry;
        public string ContrafuertesEntry
        {
            get { return _ContrafuertesEntry; }
            set { SetProperty(ref _ContrafuertesEntry, value); }
        }
        private string _ArcosEntry;
        public string ArcosEntry
        {
            get { return _ArcosEntry; }
            set { SetProperty(ref _ArcosEntry, value); }
        }
        private string _VigasEntry;
        public string VigasEntry
        {
            get { return _VigasEntry; }
            set { SetProperty(ref _VigasEntry, value); }
        }
        private string _TrabesEntry;
        public string TrabesEntry
        {
            get { return _TrabesEntry; }
            set { SetProperty(ref _TrabesEntry, value); }
        } 
        private string _TorresEntry;
        public string TorresEntry
        {
            get { return _TorresEntry; }
            set { SetProperty(ref _TorresEntry, value); }
        }

        private string _EspadanasEntry;
        public string EspadanasEntry
        {
            get { return _EspadanasEntry; }
            set { SetProperty(ref _EspadanasEntry, value); }
        }
        private string _ARecubrimientosEntry;
        public string ARecubrimientosEntry
        {
            get { return _ARecubrimientosEntry; }
            set { SetProperty(ref _ARecubrimientosEntry, value); }
        }
        private string _PVentasEntry;
        public string PVentasEntry
        {
            get { return _PVentasEntry; }
            set { SetProperty(ref _PVentasEntry, value); }
        }
        private string _OrnamentosEntry;
        public string OrnamentosEntry
        {
            get { return _OrnamentosEntry; }
            set { SetProperty(ref _OrnamentosEntry, value); }
        }
        private string _CandelabrosEntry;
        public string CandelabrosEntry
        {
            get { return _CandelabrosEntry; }
            set { SetProperty(ref _CandelabrosEntry, value); }
        } 
        private string _PCielosrasosEntry;
        public string PCielosrasosEntry
        {
            get { return _PCielosrasosEntry; }
            set { SetProperty(ref _PCielosrasosEntry, value); }
        }
        private string _RetablosEntry;
        public string RetablosEntry
        {
            get { return _RetablosEntry; }
            set { SetProperty(ref _RetablosEntry, value); }
        }

        //Imagen
        public ImageSource ImageSendForms
        {
            get
            {
                //return ImageSource.FromResource("ButtonRendererDemo.Resources.icon1.png"); //from PCL
                return ImageSource.FromResource(file_path); //from Shared
            }
        }
        #endregion
    }
}