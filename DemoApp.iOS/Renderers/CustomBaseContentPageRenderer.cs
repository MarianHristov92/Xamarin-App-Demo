using System;
using DemoApp.Base.Views;
using DemoApp.iOS.Renderers;
using DemoApp.Styles;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BaseContentPage), typeof(CustomBaseContentPageRenderer))]
namespace DemoApp.iOS.Renderers
{
    public class CustomBaseContentPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            SetAppTheme();
        }


        public override void TraitCollectionDidChange(UITraitCollection previousTraitCollection)
        {
            if (previousTraitCollection == null)
                return;
            else
            {
                base.TraitCollectionDidChange(previousTraitCollection);
                Console.WriteLine($"TraitCollectionDidChange: {TraitCollection.UserInterfaceStyle} != {previousTraitCollection.UserInterfaceStyle}");

                if (this.TraitCollection.UserInterfaceStyle != previousTraitCollection.UserInterfaceStyle)
                {
                    SetAppTheme();
                }
            }
        }

        void SetAppTheme()
        {
            if (this.TraitCollection.UserInterfaceStyle == UIUserInterfaceStyle.Dark)
            {
                if (App.AppTheme == "dark")
                    return;

                App.Current.Resources = new DarkTheme();

                App.AppTheme = "dark";
            }
            else
            {
                if (!string.IsNullOrEmpty(App.AppTheme))
                {
                    if (App.AppTheme != "dark") return;
                    App.Current.Resources = new LightTheme();
                    App.AppTheme = "light";
                }
                else
                {
                    App.Current.Resources = new LightTheme();
                    App.AppTheme = "light";
                }
            }
        }
    }

}