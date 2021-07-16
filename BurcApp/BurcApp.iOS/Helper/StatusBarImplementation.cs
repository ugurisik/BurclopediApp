using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BurcApp.Helper;
using BurcApp.iOS.Helper;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarImplementation))]
namespace BurcApp.iOS.Helper
{
    public class StatusBarImplementation : IStatusBar
    {
        public void HideStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = true;
        }
        public void ShowStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = false;
        }
    }
}