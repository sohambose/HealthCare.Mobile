using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media.Abstractions;

namespace HealthCare.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CaptureDocument : ContentPage
    {
        public CaptureDocument()
        {
            InitializeComponent();
        }

        private async void btnOpenCamera_Clicked(object sender, EventArgs e)
        {
            bool IsCameraMode = true;
            await Navigation.PushAsync(new CaptureAndProcessImage(IsCameraMode));
        }

        private async void btnOpenGallery_Clicked(object sender, EventArgs e)
        {
            bool IsCameraMode = false;
            await Navigation.PushAsync(new CaptureAndProcessImage(IsCameraMode));
        }
    }
}