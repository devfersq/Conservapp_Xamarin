using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android;

namespace Conservapp.Droid
{
    [Activity(Label = "Conservapp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const int RequestId = 0;

        readonly string[] LocationPermissions =
        {
        Manifest.Permission.AccessCoarseLocation,
        Manifest.Permission.AccessFineLocation
    };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            #region Google Maps
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            //Xamarin.FormsGoogleMaps.Init(this, savedInstanceState);
            #endregion
            LoadApplication(new App());
        }
        protected override void OnStart()
        {
            try
            {
                base.OnStart();

                if ((int)Build.VERSION.SdkInt >= 23)
                {
                    if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                        RequestPermissions(LocationPermissions, RequestId);
                }
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
           
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}