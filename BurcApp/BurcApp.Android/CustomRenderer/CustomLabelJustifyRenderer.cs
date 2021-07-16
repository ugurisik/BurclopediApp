using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using BurcApp.CustomRenderer;
using BurcApp.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabelJustify), typeof(CustomLabelJustifyRenderer))]
namespace BurcApp.Droid.CustomRenderer
{
    public class CustomLabelJustifyRenderer : LabelRenderer
    {
        public CustomLabelJustifyRenderer(Context context) : base(context){}

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
                {
                    Control.JustificationMode = Android.Text.JustificationMode.InterWord;
                }
            }
        }
    }
}