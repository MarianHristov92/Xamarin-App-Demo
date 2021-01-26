using DemoApp.Base.Models;
using DemoApp.Base.ViewModels;
using DemoAppBackendApi;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Track = DemoApp.Base.Models.Track;

namespace DemoApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        readonly TimeSpan _loginTimeout = TimeSpan.FromSeconds(20);
        private bool _isLoggedIn;

        #region Properties
        private string _emailAddress;
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { SetProperty(ref _emailAddress, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private bool _passwordIsHidden;
        public bool PasswordIsHidden
        {
            get { return _passwordIsHidden; }
            set { SetProperty(ref _passwordIsHidden, value); }
        }

        private string _previousPage;
        public string PreviousPage
        {
            get { return _previousPage; }
            set { SetProperty(ref _previousPage, value); }
        }

        bool _waitingToProcess;
        public bool WaitingToProcess
        {
            get { return _waitingToProcess; }
            set { SetProperty(ref _waitingToProcess, value); }
        }
        #endregion

        #region Ctor
        public LoginPageViewModel()
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

        void Initialize()
        {
            string tag = this + ".Initialize";
            try
            {
                PasswordIsHidden = true;
                SetupCommands();
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
                LoginCommand = new Command(LoginActionAsync);
                PasswordForgottenCommand = new Command(PasswordForgottenAction);
                OnPasswordHideIconTappedCommand = new Command(OnPasswordHideIconTappedCommandAction);
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

        public ICommand LoginCommand { get; private set; }
        public async void LoginActionAsync()
        {
            string tag = this + ".LoginAction";
            try
            {
                Device.BeginInvokeOnMainThread(() => LoadingDialog.ShowDialog());

                //TODO: FIX GATEWAY LATER
                //Gateway.Instance.Identity.Login(EmailAddress, Password);
                await Shell.Current.GoToAsync("../..");

            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public ICommand PasswordForgottenCommand { get; private set; }
        public async void PasswordForgottenAction()
        {
            string tag = this + ".PasswordForgottenAction";
            try
            {
                await Shell.Current.GoToAsync("PasswordForgottenPage");
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public ICommand OnPasswordHideIconTappedCommand { get; private set; }
        private void OnPasswordHideIconTappedCommandAction()
        {
            string tag = this + ".OnPasswordHideIconTappedCommandAction";
            try
            {
                PasswordIsHidden = !PasswordIsHidden;
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion
    }
}