using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BurcApp.CustomRenderer;
using BurcApp.iOS.CustomRenderer;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomLabelJustify), typeof(CustomLabelJustifyRenderer))]
namespace BurcApp.iOS.CustomRenderer
{
    public class CustomLabelJustifyRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.TextAlignment = UITextAlignment.Justified;
            }
        }
    }
}