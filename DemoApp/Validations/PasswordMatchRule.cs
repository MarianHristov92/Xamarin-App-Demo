using System;
using DemoApp.Validations.Interfaces;

namespace DemoApp.Validations
{
    public class PasswordMatchRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public ValidatableObject<string> otherPassword { get; set; }

        public PasswordMatchRule(ref ValidatableObject<string> otherPassword)
        {
            this.otherPassword = otherPassword;
        }

        public bool Check(T value)
        {
            if (value == null && otherPassword == null)
            {
                ValidationMessage = "Oops, unfortunately an error occurred. Please try again:";
                throw new Exception("Passwords don't match!!");
            }

            var password = value as string;

            if (password == otherPassword.Value)
                return true;

            ValidationMessage = "Passwords don't match!";
            return false;
        }
    }
}
