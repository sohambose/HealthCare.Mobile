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

            //btnOpenCamera.Clicked += async (sender, args) =>
            //{

            //};


        }

        private async void btnOpenCamera_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (CrossMedia.Current.IsTakePhotoSupported)
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "captured_images",
                    Name = DateTime.Now.ToFileTime().ToString()
                }); ;
                if (file != null)
                {
                    await DisplayAlert("File Path-", file.Path, "OK");
                }

                imgCaptured.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
        }

        private async void btnOpenGallery_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium
                });
                if (file != null)
                {
                    await DisplayAlert("File Path-", file.Path, "OK");
                }

                imgCaptured.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
        }
    }
}