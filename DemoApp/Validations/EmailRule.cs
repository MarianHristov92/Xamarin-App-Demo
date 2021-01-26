using System;
using System.Text.RegularExpressions;
using DemoApp.Validations.Interfaces;

namespace DemoApp.Validations
{
    public class EmailRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            Regex regex = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-zA-ZäÄÖöüÜß]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-ZäÄÖöüÜß])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-ZäÄÖöüÜß][-0-9a-zA-ZäÄÖöüÜß]*[0-9a-zA-ZäÄÖöüÜß]*\.)+[a-zA-ZäÄÖöüÜß0-9][\-a-zA-ZäÄÖöüÜß0-9]{0,22}[a-zA-ZäÄÖöüÜß0-9]))$");
            Match match = regex.Match(str);

            return match.Success;
        }
    }
}
