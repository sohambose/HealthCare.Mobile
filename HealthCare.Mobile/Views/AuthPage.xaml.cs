using HealthCare.Mobile.ServiceLayer.Authentications;
using HealthCare.Mobile.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthCare.Mobile
{

    //public class FireBaseEmailLoginRequest
    //{
    //    public string email;
    //    public string password;
    //    public bool returnSecureToken;
    //}

    //public class FireBaseEmailLoginResponse
    //{
    //    public string idToken;
    //    public string email;
    //    public string refreshToken;
    //    public string expiresIn;
    //    public string localId;
    //    public bool registered;
    //}


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        bool IsEmailLogin = true;
        private HttpClient _httpClient = new HttpClient();
        public AuthPage()
        {
            InitializeComponent();

            txtEmailPwd.IsPassword = true;
            txtOTP.IsVisible = false;
            IsEmailLogin = true;
        }

        #region <-----------------------Page Events---------------------------->
        private void btnShowHidePwd_Clicked(object sender, EventArgs e)
        {
            bool IsHidden = txtEmailPwd.IsPassword;
            txtEmailPwd.IsPassword = !IsHidden;

            if (txtEmailPwd.IsPassword)
                btnShowHidePwd.Source = "showpassword.png";
            else
                btnShowHidePwd.Source = "hidepassword.png";
        }

        private void btnAuthOption_Clicked(object sender, EventArgs e)
        {
            if (IsEmailLogin)
            {
                btnAuthOption.Text = "Login Using Email";
                txtEmailID.Placeholder = "Phone No";
                txtEmailID.Keyboard = Keyboard.Telephone;
                txtOTP.IsVisible = true;
                txtEmailPwd.IsVisible = false;
                btnShowHidePwd.IsVisible = false;
                IsEmailLogin = false;
            }
            else
            {
                btnAuthOption.Text = "Login Using Phone";
                txtEmailID.Placeholder = "Email Address";
                txtOTP.IsVisible = false;
                txtEmailPwd.IsVisible = true;
                btnShowHidePwd.IsVisible = true;
                IsEmailLogin = true;
            }
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            spnrlogin.IsVisible = spnrlogin.IsRunning = true;
            FirebaseAuthentication fbaObj = new FirebaseAuthentication();
            string errMsg = await fbaObj.HandleFirebaseAuthentication(true, txtEmailID.Text, txtEmailPwd.Text);
            spnrlogin.IsVisible = spnrlogin.IsRunning = false;

            if (string.IsNullOrEmpty(errMsg))
                await Navigation.PushAsync(new Home(), true);
            else
                await DisplayAlert("Oops!!", errMsg, "OK");
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register(), true);
        }
        #endregion

    }
}