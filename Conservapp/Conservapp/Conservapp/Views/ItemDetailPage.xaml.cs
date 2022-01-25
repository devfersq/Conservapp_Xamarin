using Conservapp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Conservapp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}