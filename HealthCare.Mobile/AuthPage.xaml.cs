using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthCare.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        bool IsEmailLogin = true;
        public AuthPage()
        {
            InitializeComponent();
            txtEmailPwd.IsPassword = true;
            txtOTP.IsVisible = false;
            IsEmailLogin = true;
        }

        #region <-----------------------Events---------------------------->
        private void btnShowHidePwd_Clicked(object sender, EventArgs e)
        {
            bool IsHidden = txtEmailPwd.IsPassword;
            txtEmailPwd.IsPassword = !IsHidden;

            if (txtEmailPwd.IsPassword)
                btnShowHidePwd.Source = "showpassword.png";
            else
                btnShowHidePwd.Source = "hidepassword.png";
        }
        #endregion

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
    }
}