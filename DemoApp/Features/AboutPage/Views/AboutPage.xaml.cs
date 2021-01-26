using System;
using System.ComponentModel;
using DemoApp.Base.Models;
using DemoApp.Base.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp.Features.AboutPage.Views
{

    public partial class AboutPage : BaseContentPage
    {
        public double FontSize { get; set; }
        public double HeightRequestSize { get; set; }
        public double SVGSize { get; set; }

        public AboutPage()
        {
            string tag = this + ".Ctor";
            try
            {
                SetUpFontSize();
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        public void SetUpFontSize()
        {
            var tag = this + ".SetUpFontSize";
            try
            {
                // Get Metrics
                var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

                // Width (in pixels)
                var width = mainDisplayInfo.Width;

                // Height (in pixels)
                var height = mainDisplayInfo.Height;

                if ((width > 640) && (height > 1136))
                {
                    FontSize = 18;
                    HeightRequestSize = 50;
                    SVGSize = 20;
                }
                else
                {
                    FontSize = 16;
                    HeightRequestSize = 40;
                    SVGSize = 16;
                }
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public async void OnButtonTapped(object sender, EventArgs e)
        {
            string tag = this + ".OnButtonTapped";
            try
            {
                await Shell.Current.GoToAsync("DetailsPage");
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
    }
}

