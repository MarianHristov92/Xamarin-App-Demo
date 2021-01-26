using System;
using DemoApp.Base.Models;
using DemoApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace DemoApp.iOS.Renderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        public double AccessibilitySizeFactor
        {
            get
            {
                var sizeCategory = UIKit.UIApplication.SharedApplication.PreferredContentSizeCategory;
                double factor = 1;

                // Factors have been reverse-engineered by comparing a font size of 16pt (= 45px)
                // with the corresponding sizes in ListView
                double baseSize = 45;
                switch (sizeCategory)
                {
                    case "UICTContentSizeCategoryXS":
                        factor = 39 / baseSize;
                        break;
                    case "UICTContentSizeCategoryS":
                        factor = 42 / baseSize;
                        break;
                    case "UICTContentSizeCategoryM":
                        factor = 1;
                        break;
                    case "UICTContentSizeCategoryL":
                        factor = 48 / baseSize;
                        break;
                    case "UICTContentSizeCategoryXL":
                        factor = 53 / baseSize;
                        break;
                    case "UICTContentSizeCategoryXXL":
                        factor = 57 / baseSize;
                        break;
                    case "UICTContentSizeCategoryXXXL":
                        factor = 63 / baseSize;
                        break;
                }

                return factor;
            }
        }

        public CustomButtonRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            Button button;
            if (e.NewElement == null)
                return;
            else
                button = e.NewElement;
            var accessibilityChangableFontSize = AttachedProperties.GetAccessibilityChangeableFontSize(button);
            if (accessibilityChangableFontSize)
            {
                button.FontSize = button.FontSize * AccessibilitySizeFactor;
                AttachedProperties.SetAccessibilityChangeableFontSize(button, false);
            }
        }
    }
}
