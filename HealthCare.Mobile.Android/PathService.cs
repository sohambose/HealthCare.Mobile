using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using HealthCare.Mobile.Interfaces;
using Xamarin.Forms;
using Application = Android.App.Application;


namespace HealthCare.Mobile.Droid
{
    public class PathService : IPathService
    {
        //https://kimsereyblog.blogspot.com/2016/11/differences-between-internal-and.html
        public string InternalFolder
        {
            get
            {
                return Android.App.Application.Context.FilesDir.AbsolutePath;
            }
        }

        public string PublicExternalFolder
        {
            get
            {
                return Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            }
        }

        public string PrivateExternalFolder
        {
            get
            {
                return Application.Context.GetExternalFilesDir(null).AbsolutePath;
            }
        }

    }
}