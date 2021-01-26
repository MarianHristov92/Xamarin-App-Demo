using System;
using System.Collections.Generic;
using DemoApp.Base.Models;
using DemoApp.Base.Views;
using DemoApp.ViewModels;
using DemoAppBackendApi.Events;
using EventBus;
using EventBus.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace DemoApp.Features.LoginPage.Views
{
    public partial class LoginPage : BaseContentPage
    {
        #region Properties
        private ISubscription<LoginFailedEvent> LoginFailedSub { get; set; }
        public string PreviousPage { get; set; }
        #endregion

        #region Ctor
        public LoginPage()
        {
            MessageBus.Instance.ClearSubscriptions(typeof(LoginFailedEvent));
            LoginFailedSub = MessageBus.Instance.Subscribe<LoginFailedEvent>(OnLoginFailed);
            InitializeComponent();

        }
        #endregion

        #region Events
        public async void OnLoginFailed(LoginFailedEvent obj)
        {
            string tag = this + ".OnLoginFailed";
            try
            {
                Device.BeginInvokeOnMainThread(() => LoadingDialog.HideDialog());
                await DisplayAlert("Login Failed", "Username or password was not correct", "OK");
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

        private void OnPasswordEntryFinished(object sender, EventArgs e)
        {
            LoginButton.Command.Execute(null);
        }
        #endregion
    }
}
