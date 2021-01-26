using System;
using DemoApp.Validations.Interfaces;

namespace DemoApp.Validations
{
    public class PasswordRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            if (str.Length >= 8)
                return true;

            return false;
        }
    }
}
