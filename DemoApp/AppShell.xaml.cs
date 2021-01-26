using System;
using System.Collections.Generic;
using DemoApp.Base.Models;
using DemoApp.Features.AboutPage.Views;
using DemoApp.Features.LoginPage.Views;
using DemoApp.Features.MainPage.Views;
using DemoApp.Features.SettingsPage.Views;
using Xamarin.Forms;

namespace DemoApp
{
    public partial class AppShell : Shell
    {
        #region Properties
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        #endregion
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            routes.Add("AboutPage", typeof(AboutPage));
            routes.Add("DetailsPage", typeof(DetailsPage));
            routes.Add("MainPage", typeof(MainPage));
            routes.Add("LoginPage", typeof(LoginPage));
            routes.Add("PasswordForgottenPage", typeof(PasswordForgottenPage));
            routes.Add("RegistrationPage", typeof(RegistrationPage));
            routes.Add("SettingsPage", typeof(SettingsPage));
            
            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            string tag = this + ".OnBackButtonPressed";
            try
            {
                var page = (Shell.Current?.CurrentItem?.CurrentItem as IShellSectionController)?.PresentedPage;
                if (page != null && page.SendBackButtonPressed())
                    return true;
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }

            return base.OnBackButtonPressed();
        }
    }
}