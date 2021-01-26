using System;
using System.Collections.Generic;
using System.Windows.Input;
using DemoApp.Base.Models;
using DemoApp.Base.ViewModels;
using DemoApp.Models;
using DemoAppBackendApi;
using DemoAppBackendApi.Base.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Track = DemoApp.Base.Models.Track;

namespace DemoApp.Features.MainPage.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Properties
        private List<BaseFeedItem> _feedItemsList;
        public List<BaseFeedItem> FeedItemsList
        {
            get { return _feedItemsList; }
            set { SetProperty(ref _feedItemsList, value); }
        }
        #endregion

        #region Ctor
        public MainPageViewModel()
        {
            string tag = this + ".ctor";
            try
            {
                Initialize();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        private void Initialize()
        {
            string tag = this + ".Initialize";
            try
            {
                SetupCommands();
                GetFeed();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        private void GetFeed()
        {
            string tag = this + ".Initialize";
            try
            {
                if (Gateway.Instance.BaseApi.FeedItemsList != null)
                    FeedItemsList = Gateway.Instance.BaseApi.FeedItemsList;
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
            
        }

        private void SetupCommands()
        {
            string tag = this + ".SetupCommands";
            try
            {
                CreateAccountCommand = new Command(CreateAccountAction);
                RegisterAccountCommand = new Command(RegisterAccountAction);
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

        #region Commands
        public ICommand CreateAccountCommand { get; private set; }
        public async void CreateAccountAction()
        {
            string tag = this + ".CreateAccountAction";
            try
            {
                await Shell.Current.GoToAsync("RegistrationPage");
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public ICommand RegisterAccountCommand { get; private set; }
        public async void RegisterAccountAction()
        {
            string tag = this + ".RegisterAccountAction";
            try
            {
                await Shell.Current.GoToAsync("//MainPage", animate: false);
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

        public ICommand OnItemTappedCommand => new Command<MainPageItem>(OnItemTappedCommandAction);
        private async void OnItemTappedCommandAction(MainPageItem MainItem)
        {
            string tag = this + ".OnItemTappedCommandAction";
            try
            {
                string NavigationPath = MainItem.NavigationPath;
                await Shell.Current.GoToAsync($"//MainPage//{NavigationPath}");
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public ICommand OnFeedItemTappedCommand => new Command<BaseFeedItem>(OnFeedItemTappedCommandAction);
        private async void OnFeedItemTappedCommandAction(BaseFeedItem FeedItem)
        {
            string tag = this + ".OnFeedItemTappedCommandAction";
            try
            {
                Uri uri = new Uri(FeedItem.LinkUrl);

                if (Device.RuntimePlatform == Device.iOS)
                {
                    await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
                }

                if (Device.RuntimePlatform == Device.Android)
                {
                    await Launcher.OpenAsync(uri);
                }
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
    }
}
