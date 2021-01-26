using DemoApp.Base.Models;
using DemoApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Label), typeof(CustomLabelRenderer))]
namespace DemoApp.iOS.Renderers
{
    public class CustomLabelRenderer : LabelRenderer
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

        public CustomLabelRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            Label label;
            if (e.NewElement == null)
                return;
            else
                label = e.NewElement;
            var accessibilityChangableFontSize = AttachedProperties.GetAccessibilityChangeableFontSize(label);
            if (accessibilityChangableFontSize)
            {
                label.FontSize = label.FontSize * AccessibilitySizeFactor;
                AttachedProperties.SetAccessibilityChangeableFontSize(label, false);
            }
        }
    }
}
