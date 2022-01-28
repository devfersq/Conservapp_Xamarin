using System;

namespace Conservapp.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        public MapViewModel()
        {
            try
            {
                Title = "Ubicación";
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
        }
    }
}
