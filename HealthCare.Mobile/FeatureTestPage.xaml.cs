using HealthCare.Mobile.Models;
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
    public partial class FeatureTestPage : ContentPage
    {
        public FeatureTestPage()
        {
            InitializeComponent();

            //----------------------URI Images------------------------------------------------------------------------
            //var imgSource = (UriImageSource)ImageSource.FromUri(new Uri("http://lorempixel.com/1920/1080/sports/"));
            //imgSource.CachingEnabled = false;
            //img1.Source = imgSource;
            //img1.Source = "http://lorempixel.com/1920/1080/sports/";
            //--------------------------------------------------------------------------------------------------------

            //-------------------Emebedded Images---------------------------------------------------------------------
            //img1.Source = ImageSource.FromResource("HealthCare.Mobile.Images.SampleBackground.jpg");
            //--------------------------------------------------------------------------------------------------------

            List<Member> lstMember = new List<Member>();

            Member memObj = new Member();
            memObj.Name = "AAA";
            memObj.Status = "Active";
            memObj.ImageURL = "http://lorempixel.com/100/100/people/1/";
            lstMember.Add(memObj);

            memObj = new Member();
            memObj.Name = "BBB";
            memObj.Status = "Offline";
            memObj.ImageURL = "http://lorempixel.com/100/100/people/3/";
            lstMember.Add(memObj);

            lstMembers.ItemsSource = lstMember;


        }

        private void lstMembers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var selectedMember = e.SelectedItem as Member;
            //DisplayAlert("Selected", selectedMember.Name, "OK");
            //lstMembers.SelectedItem = null;
        }

        private void lstMembers_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //var selectedMember = e.Item as Member;
            //DisplayAlert("Tapped", selectedMember.Name, "OK");
        }

        private void DeleteItem_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Delete", "Test", "OK");
        }
        private void InactiveItem_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Inactive", "Inactive", "OK");
        }

        private void lstMembers_Refreshing(object sender, EventArgs e)
        {
            lstMembers.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}