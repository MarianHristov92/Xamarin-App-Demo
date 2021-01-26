using System;
using DemoApp.Base.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DemoApp.Base.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        double _logoImageTranslation;
        public double LogoImageTranslation
        {
            get { return _logoImageTranslation; }
            set { SetProperty(ref _logoImageTranslation, value); }
        }

        public ViewModelBase()
        {
            SetupTranslationSize();
        }

        public void SetupTranslationSize()
        {

            var height = DeviceDisplay.MainDisplayInfo.Height;
            var width = DeviceDisplay.MainDisplayInfo.Width;
            var translationRatio = 0.01010305958;

            if (Device.RuntimePlatform == Device.iOS)
            {
                LogoImageTranslation = translationRatio * width;
                RaisePropertyChanged("LogoImageTranslation");
            }
            else
            {
                LogoImageTranslation = 0;
                RaisePropertyChanged("LogoImageTranslation");
            }
        }

        public async void GoBack(string query = null)
        {
            string tag = this + ".GoBack";
            try
            {
                await Shell.Current.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
    }
}

