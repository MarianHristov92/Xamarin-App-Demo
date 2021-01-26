using System;
using System.ComponentModel;
using DemoApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
namespace DemoApp.iOS.Renderers
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            //if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            //{
            //    OverrideUserInterfaceStyle = UIUserInterfaceStyle.Light;
            //}
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null)
            {
                if (Control.Text != null && Control.Text.Length > 20)
                    Control.Text = string.Format("{0} ...", Control.Text.Substring(0, 17));

                Control.BorderStyle = UIKit.UITextBorderStyle.None;
                Control.TextColor = UIKit.UIColor.FromRGB(112, 112, 112);
            }
        }
    }
}