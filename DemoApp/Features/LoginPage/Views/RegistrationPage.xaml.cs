using System;
using System.Collections.Generic;
using System.Linq;
using DemoApp.Base.Models;
using DemoApp.Base.Views;
using DemoApp.Features.LoginPage.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace DemoApp.Features.LoginPage.Views
{
    [QueryProperty("PreviousPage", "previousPage")]
    public partial class RegistrationPage : BaseContentPage
    {
        public string PreviousPage
        {
            set
            {
                var vm = BindingContext as RegistrationPageViewModel;
                if (vm == null) return;
                vm.PreviousPage = Uri.UnescapeDataString(value);
            }
        }

        #region Ctor
        public RegistrationPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Pan);
        }
        #endregion

        #region Events
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }

        public void OnGenderFrameTapped(object sender, EventArgs e)
        {
            string tag = this + ".OnGenderFrameTapped";
            try
            {
                GenderPicker.Focus();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public void OnFirstNameFrameTapped(object sender, EventArgs e)
        {
            string tag = this + ".OnFirstNameFrameTapped";
            try
            {
                FirstNameEntry.Focus();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public void OnLastNameFrameTapped(object sender, EventArgs e)
        {
            string tag = this + ".OnLastNameFrameTapped";
            try
            {
                LastNameEntry.Focus();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public void OnEmailAddressFrameTapped(object sender, EventArgs e)
        {
            string tag = this + ".OnEmailAddressFrameTapped";
            try
            {
                EmailAddressEntry.Focus();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public void OnPasswordFrameTapped(object sender, EventArgs e)
        {
            string tag = this + ".OnPasswordFrameTapped";
            try
            {
                PasswordEntry.Focus();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public void OnRepeatPasswordFrameTapped(object sender, EventArgs e)
        {
            string tag = this + ".OnRepeatPasswordFrameTapped";
            try
            {
                RepeatPasswordEntry.Focus();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public async void OnFooterLabelTapped(object sender, EventArgs e)
        {
            string tag = this + ".OnFooterLabelTapped";
            try
            {
                var senderLabel = sender as Label;
                if (senderLabel == null)
                    return;
                var senderString = senderLabel.Text.Split('*', StringSplitOptions.RemoveEmptyEntries).First();
                if (senderString.Equals("Datenschutzerklärung"))
                    senderString = "Datenschutz";
                await Shell.Current.GoToAsync($"WebViewPage?pageName={senderString}");
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion
    }
}
