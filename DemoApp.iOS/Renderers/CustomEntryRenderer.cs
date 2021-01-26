using System;
using System.ComponentModel;
using DemoApp.Base.Models;
using DemoApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace DemoApp.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
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

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            Entry entry;
            if (e.NewElement == null)
                return;
            else
                entry = e.NewElement;
            var accessibilityChangableFontSize = AttachedProperties.GetAccessibilityChangeableFontSize(entry);
            if (accessibilityChangableFontSize)
            {
                entry.FontSize = entry.FontSize * AccessibilitySizeFactor;
                AttachedProperties.SetAccessibilityChangeableFontSize(entry, false);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null)
            {
                Control.BorderStyle = UIKit.UITextBorderStyle.None;

                var entry = sender as Entry;
                if (entry == null)
                    return;

                if (entry.AutomationId == "MyPBEntry")
                    Control.Font = UIFont.FromName("SourceSansPro-Regular", 12);
            }
        }
    }
}