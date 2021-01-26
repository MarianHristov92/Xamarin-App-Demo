using System;
using System.Collections.Generic;
using DemoApp.Base.Models;
using DemoApp.Base.Views;
using Xamarin.Forms;

namespace DemoApp.Features.SettingsPage.Views
{
    public partial class SettingsPage : BaseContentPage
    {
        public double FontSize { get; set; }
        public double HeightRequestSize { get; set; }
        public double SVGSize { get; set; }

        public SettingsPage()
        {
            string tag = this + ".Ctor";
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }


        protected override void OnAppearing()
        {
            string tag = this + ".OnAppearing";
            try
            {
                base.OnAppearing();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        protected override void OnDisappearing()
        {
            string tag = this + ".OnDisappearing";
            try
            {
                base.OnDisappearing();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        #region Events
        public async void OnSwitch1Toggled(object sender, EventArgs e)
        {
            string tag = this + ".OnSwitch1Toggled";
            try
            {

            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public async void OnSwitch2Toggled(object sender, EventArgs e)
        {
            string tag = this + ".OnSwitch2Toggled";
            try
            {

            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public async void OnSwitch3Toggled(object sender, EventArgs e)
        {
            string tag = this + ".OnSwitch3Toggled";
            try
            {

            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion
    }
}
