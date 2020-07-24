using HealthCare.Mobile.ServiceLayer.Authentications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthCare.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        private HttpClient _httpClient = new HttpClient();

        public Register()
        {
            InitializeComponent();
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            spnrlogin.IsVisible = spnrlogin.IsRunning = true;
            FirebaseAuthentication fbaObj = new FirebaseAuthentication();
            string errMsg = await fbaObj.HandleFirebaseAuthentication(false, txtEmailID.Text, txtPassword.Text);
            spnrlogin.IsVisible = spnrlogin.IsRunning = false;

            if (string.IsNullOrEmpty(errMsg))
                await Navigation.PushAsync(new Home(), true);
            else
                await DisplayAlert("Oops!!", errMsg, "OK");
        }

        private async void btnGotoLogin_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AuthPage(), true);
        }
    }
}