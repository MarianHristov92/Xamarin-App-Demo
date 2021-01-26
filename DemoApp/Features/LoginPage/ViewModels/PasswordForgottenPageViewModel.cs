using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoApp.Base.Models;
using DemoApp.Base.ViewModels;
using DemoApp.Validations;
using DemoAppBackendApi;
using DemoAppBackendApi.Events;
using EventBus;
using EventBus.Interfaces;
using Xamarin.Forms;
using Track = DemoAppBackendApi.Track;

namespace DemoApp.Features.LoginPage.ViewModels
{
    public class PasswordForgottenPageViewModel : ViewModelBase
    {
        #region Properties
        public ISubscription<PasswordRecoverySuccessfulEvent> PasswordRecoverySuccessfulEventSub;
        public ISubscription<PasswordRecoveryFailedEvent> PasswordRecoveryFailedEventSub;

        private bool _isPasswordForgottenCompleteScreen;
        public bool IsPasswordForgottenCompleteScreen
        {
            get { return _isPasswordForgottenCompleteScreen; }
            set { SetProperty(ref _isPasswordForgottenCompleteScreen, value); }
        }

        private string _passwordForgottenCompleteScreenText;
        public string PasswordForgottenCompleteScreenText
        {
            get { return _passwordForgottenCompleteScreenText; }
            set { SetProperty(ref _passwordForgottenCompleteScreenText, value); }
        }

        ValidatableObject<string> _email;
        public ValidatableObject<string> Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _emailLabelText;
        public string EmailLabelText
        {
            get { return _emailLabelText; }
            set { SetProperty(ref _emailLabelText, value); }
        }
        #endregion

        #region Constructor
        public PasswordForgottenPageViewModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            string tag = this + ".Initialize";
            try
            {
                SubscribeEvents();
                SetupCommands();
                InitializeEntries();
                AddValidations();

                IsPasswordForgottenCompleteScreen = false;
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public void SubscribeEvents()
        {
            string tag = this + ".SubscribeEvents";
            try
            {
                PasswordRecoverySuccessfulEventSub = MessageBus.Instance.Subscribe<PasswordRecoverySuccessfulEvent>(OnPasswordRecoverySuccessful);
                PasswordRecoveryFailedEventSub = MessageBus.Instance.Subscribe<PasswordRecoveryFailedEvent>(OnPasswordRecoveryFailed);
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public void SetupCommands()
        {
            string tag = this + ".SetupCommands";
            try
            {
                RecoverPasswordCommand = new Command(RecoverPasswordCommandActionAsync);

                // Validations
                ValidateEmailCommand = new Command<EventParameterObject>((eventParameterObject) => ValidateEmailCommandAction(eventParameterObject));
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        private void InitializeEntries()
        {
            string tag = this + ".InitializeEntries";
            try
            {
                EmailLabelText = "E-mail Adresse";

                _email = new ValidatableObject<string>();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        private void AddValidations()
        {
            string tag = this + ".AddValidations";
            try
            {
                _email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Please provide a valid email!" });
                _email.Validations.Add(new EmailRule<string> { ValidationMessage = "Invalid Email" });
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

        #region Methods - Commands
        public ICommand RecoverPasswordCommand { get; private set; }
        public async void RecoverPasswordCommandActionAsync()
        {
            string tag = this + ".RecoverPasswordCommandAction";
            try
            {
                //TODO: FIX GATEWAY LATER
                //if (_email.IsValid)
                //    Gateway.Instance.Identity.RecoverPassword(Email.Value);

                await Shell.Current.GoToAsync("../..");

            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

        #region Commands - Validation
        public ICommand ValidateEmailCommand { get; private set; }
        private bool ValidateEmailCommandAction(EventParameterObject eventParameterObject = null)
        {
            var result = _email.Validate();
            if (_email.Errors.Any() && !_email.IsValid)
            {
                EmailLabelText = _email.Errors.FirstOrDefault();
            }
            else
            {
                EmailLabelText = "E-mail Adresse";
            }
            return result;
        }
        #endregion

        #region Methods - Events
        public void OnPasswordRecoverySuccessful(PasswordRecoverySuccessfulEvent obj)
        {
            string tag = this + ".OnPasswordRecoverySuccessful";
            try
            {
                MessageBus.Instance.UnSubscribe(PasswordRecoverySuccessfulEventSub);
                MessageBus.Instance.UnSubscribe(PasswordRecoveryFailedEventSub);
                Device.BeginInvokeOnMainThread(() => App.Current.MainPage.DisplayAlert("Forgotten Password", "We will send you a link to recover your password.", "OK"));
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public void OnPasswordRecoveryFailed(PasswordRecoveryFailedEvent obj)
        {
            string tag = this + ".OnPasswordRecoveryFailed";
            try
            {
                App.Current.MainPage.DisplayAlert("Forgotten Password", "The specified e-mail address could not be found!", "OK");
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion
    }
}
