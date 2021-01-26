using System;
using System.Collections.Generic;
using System.ComponentModel;
using DemoApp.Base.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace DemoApp.Base.Views
{
    public partial class BaseContentPage : ContentPage
    {
        public static readonly BindableProperty TitleImageProperty =
            BindableProperty.Create("TitleImage", typeof(string), typeof(BaseContentPage), null);

        public static readonly BindableProperty TitleLogoImageProperty =
            BindableProperty.Create("TitleLogoImage", typeof(string), typeof(BaseContentPage), null);

        public static readonly BindableProperty TitleImageHeightProperty =
            BindableProperty.Create("TitleImageHeight", typeof(double), typeof(BaseContentPage), null);

        public static readonly BindableProperty TitleImageWidthProperty =
            BindableProperty.Create("TitleImageWidth", typeof(double), typeof(BaseContentPage), null);

        public IList<View> FrameContent => BaseGrid.Children;

        public double TitleImageHeight
        {
            get { return (double)GetValue(TitleImageHeightProperty); }
            set { SetValue(TitleImageHeightProperty, value); }
        }

        public double TitleImageWidth
        {
            get { return (double)GetValue(TitleImageWidthProperty); }
            set { SetValue(TitleImageWidthProperty, value); }
        }

        public string TitleImage
        {
            get { return (string)GetValue(TitleImageProperty); }
            set { SetValue(TitleImageProperty, value); }
        }

        public string TitleLogoImage
        {
            get { return (string)GetValue(TitleLogoImageProperty); }
            set { SetValue(TitleLogoImageProperty, value); }
        }

        public BaseContentPage()
        {
            InitializeComponent();
        }

        #region TitleView
        public void OnTitleViewGridPropertyChanged(object sender, EventArgs e)
        {
            string tag = this + ".OnTitleViewGridPropertyChanged";
            try
            {
                Track.Info(tag, "called");
                if (TitleViewGrid.Width > 0)
                {
                    TitleViewGrid.PropertyChanged -= OnTitleViewGridPropertyChanged;
                    var DisplayWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
                    var HamburgerWidth = DisplayWidth - TitleViewGrid.Width;
                    SetTitleViewBox(HamburgerWidth);
                }
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }

        }

        private void SetTitleViewBox(double width)
        {
            string tag = this + ".SetTitleViewBox";
            try
            {
                TitleViewBox.WidthRequest = width;
                TitleImageHeight = 25;
                TitleViewBox.HorizontalOptions = LayoutOptions.EndAndExpand;
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        #endregion

        #region BaseContent
        public void OnPancakePropertyChanged(object sender, EventArgs e)
        {
            string tag = this + ".OnPancakePropertyChanged";
            try
            {
                var args = e as PropertyChangedEventArgs;
                if (args == null)
                    return;
                if (args.PropertyName.Equals("Height"))
                    if (!On<iOS>().SafeAreaInsets().IsEmpty)
                    {
                        SetSafeAreaInsetBottomOnIOS(-On<iOS>().SafeAreaInsets().Bottom);
                    }
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }

        }

        public void SetSafeAreaInsetBottomOnIOS(double bottom)
        {
            string tag = this + ".SetSafeAreaInsetBottomOnIOS";
            try
            {
                Device.BeginInvokeOnMainThread(() => Pancake.Margin = new Thickness(Pancake.Margin.Left, Pancake.Margin.Top, Pancake.Margin.Right, bottom));
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }

        }

        public void CheckInternetConnectivity()
        {
            string tag = this + ".CheckInternetConnectivity";
            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    BackgroundColor = (Color)App.Current.Resources["OfflineModeColor"];
                    Shell.SetBackgroundColor(this, (Color)App.Current.Resources["OfflineModeColor"]);
                    TitleImageFFImageLoading.Source = ImageSource.FromFile("cloud_crossed.svg");
                }
                else
                {
                    //CheckIfCurrentStoreIsMarkthalle();
                    TitleImageFFImageLoading.Source = ImageSource.FromFile(TitleImage);
                }
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

        #region Events
        public void OnConnectivityChanged(object sender, EventArgs e)
        {
            string tag = this + ".OnConnectivityChanged";
            try
            {
                CheckInternetConnectivity();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

        #region Events
        //public void OnMyStoreChanged(MyStoreChangedEvent e)
        //{
        //    string tag = this + ".OnMyStoreChanged";
        //    try
        //    {
        //        CheckIfCurrentStoreIsMarkthalle();
        //    }
        //    catch (Exception ex)
        //    {
        //        Track.Exception(tag, ex);
        //    }
        //}
        #endregion

        #region Methods
        //public void CheckIfCurrentStoreIsMarkthalle()
        //{
        //    string tag = this + ".CheckIfCurrentStoreIsMarkthalle";
        //    try
        //    {
        //        if (Gateway.Instance.MyStore == null)
        //            return;

        //        if (Gateway.Instance.MyStore.MarktIndicator.Contains("Markthalle"))
        //        {
        //            BackgroundColor = (Color)App.Current.Resources["OffCanvasColor"];
        //            Shell.SetBackgroundColor(this, (Color)App.Current.Resources["OffCanvasColor"]);
        //        }
        //        else
        //        {
        //            BackgroundColor = (Color)App.Current.Resources["PrimaryColor"];
        //            Shell.SetBackgroundColor(this, (Color)App.Current.Resources["PrimaryColor"]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Track.Exception(tag, ex);
        //    }
        //}
        #endregion
    }
}
