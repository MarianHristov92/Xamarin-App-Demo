using System;
using System.Globalization;
using DemoApp.Base.Models;
using Xamarin.Forms;

namespace DemoApp.Converters
{
    public class EventParameterConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object eventArgs, Type targetType, object sender, CultureInfo culture)
        {
            return new EventParameterObject(sender, eventArgs as EventArgs);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
