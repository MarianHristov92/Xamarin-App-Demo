using System;
using System.Text.RegularExpressions;
using DemoApp.Validations.Interfaces;

namespace DemoApp.Validations
{
    public class OnlyCharactersRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            Regex regex = new Regex(@"^[a-zA-ZÄäÖöÜü ]+$");
            Match match = regex.Match(str);

            return match.Success;
        }
    }
}
