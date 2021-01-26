using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoApp.Base.Models;
using DemoApp.Base.ViewModels;
using DemoApp.Features.LoginPage.Views;
using DemoApp.Validations;
using DemoAppBackendApi;
using DemoAppBackendApi.Events;
using EventBus;
using EventBus.Interfaces;
using Xamarin.Forms;
using Track = DemoApp.Base.Models.Track;

namespace DemoApp.Features.LoginPage.ViewModels
{
    public class RegistrationPageViewModel : ViewModelBase
    {
        #region Properties
        private bool _isRegistrationCompleteScreen;
        public bool IsRegistrationCompleteScreen
        {
            get { return _isRegistrationCompleteScreen; }
            set { SetProperty(ref _isRegistrationCompleteScreen, value); }
        }

        private bool _passwordIsHidden;
        public bool PasswordIsHidden
        {
            get { return _passwordIsHidden; }
            set { SetProperty(ref _passwordIsHidden, value); }
        }

        private bool _repeatPasswordIsHidden;
        public bool RepeatPasswordIsHidden
        {
            get { return _repeatPasswordIsHidden; }
            set { SetProperty(ref _repeatPasswordIsHidden, value); }
        }

        ValidatableObject<string> _gender;
        public ValidatableObject<string> Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }

        private string _genderLabelText;
        public string GenderLabelText
        {
            get { return _genderLabelText; }
            set { SetProperty(ref _genderLabelText, value); }
        }

        ValidatableObject<string> _firstName;
        public ValidatableObject<string> FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _firstNameLabelText;
        public string FirstNameLabelText
        {
            get { return _firstNameLabelText; }
            set { SetProperty(ref _firstNameLabelText, value); }
        }

        ValidatableObject<string> _lastName;
        public ValidatableObject<string> LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private string _lastNameLabelText;
        public string LastNameLabelText
        {
            get { return _lastNameLabelText; }
            set { SetProperty(ref _lastNameLabelText, value); }
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

        ValidatableObject<string> _password;
        public ValidatableObject<string> Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private string _passwordLabelText;
        public string PasswordLabelText
        {
            get { return _passwordLabelText; }
            set { SetProperty(ref _passwordLabelText, value); }
        }

        ValidatableObject<string> _repeatPassword;
        public ValidatableObject<string> RepeatPassword
        {
            get { return _repeatPassword; }
            set { SetProperty(ref _repeatPassword, value); }
        }

        private string _repeatPasswordLabelText;
        public string RepeatPasswordLabelText
        {
            get { return _repeatPasswordLabelText; }
            set { SetProperty(ref _repeatPasswordLabelText, value); }
        }


        private bool _isAgreementSwitchToggled;
        public bool IsAgreementSwitchToggled
        {
            get { return _isAgreementSwitchToggled; }
            set
            {
                SetProperty(ref _isAgreementSwitchToggled, value);
                IsAgreementSwitchInitalOrToggled = _isAgreementSwitchInitial || _isAgreementSwitchToggled;
                _isAgreementSwitchInitial = false;
            }
        }

        private bool _isAgreementSwitchInitial;
        private bool IsAgreementSwitchInitial
        {
            get { return _isAgreementSwitchInitial; }
            set
            {
                SetProperty(ref _isAgreementSwitchInitial, value);
                IsAgreementSwitchInitalOrToggled = _isAgreementSwitchInitial || _isAgreementSwitchToggled;
            }
        }

        private bool _isAgreementSwitchInitalOrToggled;
        public bool IsAgreementSwitchInitalOrToggled
        {
            get { return _isAgreementSwitchInitalOrToggled; }
            set { SetProperty(ref _isAgreementSwitchInitalOrToggled, value); }
        }

        private string _previousPage;
        public string PreviousPage
        {
            get { return _previousPage; }
            set { SetProperty(ref _previousPage, value); }
        }

        private ISubscription<RegistrationCompletedEvent> RegistrationCompletedEventSub;
        private ISubscription<RegistrationFailedEvent> RegistrationFailedEventSub;
        #endregion

        #region Commands
        public ICommand ValidateGenderCommand => new Command<EventParameterObject>((eventParameterObject) => ValidateGenderCommandAction(eventParameterObject));
        public ICommand ValidateFirstNameCommand => new Command<EventParameterObject>((eventParameterObject) => ValidateFirstNameCommandAction(eventParameterObject));
        public ICommand ValidateLastNameCommand => new Command<EventParameterObject>((eventParameterObject) => ValidateLastNameCommandAction(eventParameterObject));
        public ICommand ValidateEmailCommand => new Command<EventParameterObject>((eventParameterObject) => ValidateEmailCommandAction(eventParameterObject));
        public ICommand ValidatePasswordCommand => new Command<EventParameterObject>((eventParameterObject) => ValidatePasswordCommandAction(eventParameterObject));
        public ICommand ValidateRepeatPasswordCommand => new Command<EventParameterObject>((eventParameterObject) => ValidateRepeatPasswordCommandAction(eventParameterObject));

        public ICommand ValidateFormCommand => new Command<EventParameterObject>((eventParameterObject) => ValidateFormCommandActionAsync(eventParameterObject));

        public ICommand OnPasswordHideIconTappedCommand => new Command(OnPasswordHideIconTappedCommandAction);
        public ICommand OnRepeatPasswordHideIconTappedCommand => new Command(OnRepeatPasswordHideIconTappedCommandAction);
        #endregion

        #region Ctor
        public RegistrationPageViewModel()
        {
            var tag = this + ".ctor";
            try
            {
                Initialize();
                AddValidations();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        private void Initialize()
        {
            var tag = this + ".Initialize";
            try
            {
                IsRegistrationCompleteScreen = false;

                GenderLabelText = "Gender";

                FirstNameLabelText = "First Name";

                LastNameLabelText = "Family Name";

                EmailLabelText = "E-Mail Adress";

                PasswordLabelText = "Password";

                RepeatPasswordLabelText = "Passwort repeat";

                IsAgreementSwitchInitial = true;
                IsAgreementSwitchToggled = false;
                PasswordIsHidden = true;
                RepeatPasswordIsHidden = true;

                _gender = new ValidatableObject<string>();
                _firstName = new ValidatableObject<string>();
                _lastName = new ValidatableObject<string>();
                _email = new ValidatableObject<string>();
                _password = new ValidatableObject<string>();
                _repeatPassword = new ValidatableObject<string>();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        private void AddValidations()
        {
            var tag = this + ".AddValidations";
            try
            {
                _gender.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Please choose a gender!" });

                _firstName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Please provide a first name!" });
                _firstName.Validations.Add(new OnlyCharactersRule<string> { ValidationMessage = "Only letters allowed!" });

                _lastName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Please provide a family name!" });
                _lastName.Validations.Add(new OnlyCharactersRule<string> { ValidationMessage = "Only letters allowed!" });

                _email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Please provide and Email!" });
                _email.Validations.Add(new EmailRule<string> { ValidationMessage = "Not valid E-Mail Adress" });

                _password.Validations.Add(new PasswordRule<string> { ValidationMessage = "Password min. 8 Symbols" });

                _repeatPassword.Validations.Add(new PasswordMatchRule<string>(ref _password));
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

        #region Commands - Validation
        private bool ValidateGenderCommandAction(EventParameterObject eventParameterObject = null)
        {
            var tag = this + ".ValidateGenderCommandAction";
            try
            {
                var result = _gender.Validate();
                if (_gender.Errors.Any() && !_gender.IsValid)
                    GenderLabelText = _gender.Errors.FirstOrDefault();
                else
                    GenderLabelText = "Gender";

                return result;
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
                return false;
            }
        }

        private bool ValidateFirstNameCommandAction(EventParameterObject eventParameterObject = null)
        {
            var tag = this + ".ValidateFirstNameCommandAction";
            try
            {
                var result = _firstName.Validate();
                if (_firstName.Errors.Any() && !_firstName.IsValid)
                    FirstNameLabelText = _firstName.Errors.FirstOrDefault();
                else
                    FirstNameLabelText = "First Name";

                return result;
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
                return false;
            }
        }

        private bool ValidateLastNameCommandAction(EventParameterObject eventParameterObject = null)
        {
            var tag = this + ".ValidateLastNameCommandAction";
            try
            {
                var result = _lastName.Validate();
                if (_lastName.Errors.Any() && !_lastName.IsValid)
                    LastNameLabelText = _lastName.Errors.FirstOrDefault();
                else
                    LastNameLabelText = "Family Name";
                return result;
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
                return false;
            }
        }

        private bool ValidateEmailCommandAction(EventParameterObject eventParameterObject = null)
        {
            var tag = this + ".ValidateEmailCommandAction";
            try
            {
                var result = _email.Validate();
                if (_email.Errors.Any() && !_email.IsValid)
                    EmailLabelText = _email.Errors.FirstOrDefault();
                else
                    EmailLabelText = "E-mail Adress";
                return result;
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
                return false;
            }
        }

        private bool ValidatePasswordCommandAction(EventParameterObject eventParameterObject = null)
        {
            var tag = this + ".ValidatePasswordCommandAction";
            try
            {
                var result = _password.Validate();
                if (_password.Errors.Any() && !_password.IsValid)
                {
                    PasswordLabelText = _password.Errors.FirstOrDefault();
                }
                else
                {
                    if (!_repeatPassword.IsValid)
                        ValidateRepeatPasswordCommandAction();
                    PasswordLabelText = "Password";
                }
                return result;
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
                return false;
            }
        }

        private bool ValidateRepeatPasswordCommandAction(EventParameterObject eventParameterObject = null)
        {
            var tag = this + ".ValidateRepeatPasswordCommandAction";
            try
            {
                var result = _repeatPassword.Validate();
                if (_repeatPassword.Errors.Any() && !_repeatPassword.IsValid)
                    RepeatPasswordLabelText = _repeatPassword.Errors.FirstOrDefault();
                else
                    RepeatPasswordLabelText = "Password repeat";
                return result;
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
                return false;
            }
        }

        private async Task ValidateFormCommandActionAsync(EventParameterObject eventParameterObject)
        {
            var tag = this + ".ValidateFormCommandAction";
            try
            {
                ValidateGenderCommandAction();
                ValidateFirstNameCommandAction();
                ValidateLastNameCommandAction();
                ValidateEmailCommandAction();
                ValidatePasswordCommandAction();
                ValidateRepeatPasswordCommandAction();
                IsAgreementSwitchInitial = false;

                var formIsValid = _gender.IsValid && _firstName.IsValid && _lastName.IsValid
                    && _email.IsValid && _password.IsValid && _repeatPassword.IsValid && IsAgreementSwitchToggled;

                if (formIsValid)
                {
                    Device.BeginInvokeOnMainThread(() => LoadingDialog.ShowDialog());
                    MessageBus.Instance.Subscribe<RegistrationCompletedEvent>(OnRegistrationCompleted);
                    MessageBus.Instance.Subscribe<RegistrationFailedEvent>(OnRegistrationFailed);

                    //TODO: FIX GATEWAY LATER
                    //Gateway.Instance.Identity.PerformRegistration(Gender.Value, FirstName.Value, LastName.Value, Email.Value.ToLower(), Password.Value, IsAgreementSwitchToggled);
                    await Shell.Current.GoToAsync("../..");



                }
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

        #region Commands
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

        private void OnRepeatPasswordHideIconTappedCommandAction()
        {
            string tag = this + ".OnRepeatPasswordHideIconTappedCommandAction";
            try
            {
                RepeatPasswordIsHidden = !RepeatPasswordIsHidden;
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

        #region Events
        public async void OnRegistrationCompleted(RegistrationCompletedEvent obj)
        {
            var tag = this + ".OnRegistrationCompleted";
            try
            {
                Device.BeginInvokeOnMainThread(() => LoadingDialog.HideDialog());
                MessageBus.Instance.UnSubscribe(RegistrationCompletedEventSub);
                MessageBus.Instance.UnSubscribe(RegistrationFailedEventSub);

                Toast.MakeText("You have successfully registered!", 3);

                ProcessNavigation(PreviousPage, obj);
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public void OnRegistrationFailed(RegistrationFailedEvent obj)
        {
            var tag = this + ".OnRegistrationFailed";
            try
            {
                Device.BeginInvokeOnMainThread(() => LoadingDialog.HideDialog());
                MessageBus.Instance.UnSubscribe(RegistrationCompletedEventSub);
                MessageBus.Instance.UnSubscribe(RegistrationFailedEventSub);

                Email.IsValid = false;
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

        #region Success Navigation

        private async void ProcessNavigation(string route, RegistrationCompletedEvent e)
        {
            string tag = this + ".OnUserDataReceived";
            try
            {
                if (Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 1].GetType() != typeof(RegistrationPage))
                    return;

                await Shell.Current.GoToAsync("//MainPage/" + PreviousPage);
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion
    }
}
