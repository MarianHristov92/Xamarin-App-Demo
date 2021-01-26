using System;
using DemoApp.Base.Models;
using DemoApp.Base.ViewModels;
using DemoAppBackendApi.Events;
using EventBus;
using EventBus.Interfaces;

namespace DemoApp
{
    public class AppShellViewModel : ViewModelBase
    {
        #region Properties
        ISubscription<AppLifecycleEventFinishedLaunching> FinishedLaunchingSub;
        ISubscription<AppLifecycleEventResume> ResumeSub;
        #endregion

        #region Ctor
        public AppShellViewModel()
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
                FinishedLaunchingSub = MessageBus.Instance.Subscribe<AppLifecycleEventFinishedLaunching>(OnLaunchOrResume);
                ResumeSub = MessageBus.Instance.Subscribe<AppLifecycleEventResume>(OnLaunchOrResume);
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

            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

        private void OnLaunchOrResume(AppLifecycleEventStart e)
        {
            string tag = this + ".OnLaunchOrResume";
            try
            {
                SetPrimaryColor();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        private void SetPrimaryColor()
        {
            string tag = this + ".SetPrimaryColor";
            try
            {


            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
    }
}
