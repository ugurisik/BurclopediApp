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
using BurcApp.Droid.Helper;
using BurcApp.Helper;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMessageAndroid))]
namespace BurcApp.Droid.Helper
{
    public class ToastMessageAndroid: IToastMessage
    {
        public void MesajGoster(string mesaj)
        {
            Toast.MakeText(Android.App.Application.Context, mesaj, ToastLength.Long).Show();
        }
    }
}