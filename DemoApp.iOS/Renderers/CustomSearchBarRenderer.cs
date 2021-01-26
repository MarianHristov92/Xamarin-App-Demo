using System;
using System.ComponentModel;
using DemoApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
namespace DemoApp.iOS.Renderers
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var searchbar = (UISearchBar)Control;
            if (searchbar == null)
                return;
            searchbar.SetShowsCancelButton(false, false);
            searchbar.ShowsCancelButton = false;

            // remove grey background of searchbar in ios 13 devices
            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                searchbar.SearchTextField.BackgroundColor = Element.BackgroundColor.ToUIColor();
                OverrideUserInterfaceStyle = UIUserInterfaceStyle.Light;
                Foundation.NSString _searchField = new Foundation.NSString("searchField");
                var textFieldInsideSearchBar = (UITextField)searchbar.ValueForKey(_searchField);
                textFieldInsideSearchBar.BackgroundColor = UIColor.FromRGB(255, 255, 255);
                textFieldInsideSearchBar.TextColor = UIColor.Black;
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            var searchbar = (UISearchBar)Control;

            if (e.NewElement != null)
            {
                searchbar.Layer.CornerRadius = 20;
                searchbar.Layer.BorderWidth = 0;
                searchbar.Layer.BorderColor = UIColor.FromRGB(240, 240, 240).CGColor;
                searchbar.Layer.BackgroundColor = Color.White.ToCGColor();

                // remove magnifier icon
                searchbar.SetImageforSearchBarIcon(new UIImage(), UISearchBarIcon.Search, UIControlState.Normal);

                // remove grey background of searchbar in ios 13 devices
                if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
                {
                    searchbar.SearchTextField.BackgroundColor = Element.BackgroundColor.ToUIColor();
                    //OverrideUserInterfaceStyle = UIUserInterfaceStyle.Light;

                    Foundation.NSString _searchField = new Foundation.NSString("searchField");
                    var textFieldInsideSearchBar = (UITextField)searchbar.ValueForKey(_searchField);
                    textFieldInsideSearchBar.BackgroundColor = UIColor.FromRGB(255, 255, 255);
                    textFieldInsideSearchBar.TextColor = UIColor.Black;
                }
            }
        }
    }
}
