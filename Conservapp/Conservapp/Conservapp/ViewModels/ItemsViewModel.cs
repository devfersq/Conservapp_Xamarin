using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.ComponentModel;
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

        public async void sEndFormsCommandClicked()
        {
            try
            {
                await Share.RequestAsync(new ShareTextRequest
                {
                    Subject = "[ConservApp] EVALUACIÓN RAPIDA DE DAÑOS",
                    Text = "ConservApp",
                    Title = "[ConservApp] EVALUACIÓN RAPIDA DE DAÑOS",
                    Uri = "Esto es una preuba"
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
        #endregion
    }
}