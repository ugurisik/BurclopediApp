using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BurcApp.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.RadioButton), typeof(CustomRadioButtonRenderer))]
namespace BurcApp.Droid.CustomRenderer
{
    public class CustomRadioButtonRenderer : RadioButtonRenderer
    {
        public CustomRadioButtonRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.RadioButton> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.ButtonTintList = ColorStateList.ValueOf(Android.Graphics.Color.Yellow);
            }
        }
    }
    
}