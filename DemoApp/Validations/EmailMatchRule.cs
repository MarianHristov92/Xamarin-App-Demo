using System;
using DemoApp.Validations.Interfaces;

namespace DemoApp.Validations
{
    public class EmailMatchRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public ValidatableObject<string> otherEmail { get; set; }

        public EmailMatchRule(ref ValidatableObject<string> otherEmail)
        {
            this.otherEmail = otherEmail;
        }

        public bool Check(T value)
        {
            if (value == null && otherEmail == null)
            {
                ValidationMessage = "An error occured";
                throw new Exception("otherEmail must be set");
            }

            var email = value as string;

            if (email == otherEmail.Value)
                return true;

            ValidationMessage = "No valid E-Mail Adress";
            return false;
        }
    }
}
