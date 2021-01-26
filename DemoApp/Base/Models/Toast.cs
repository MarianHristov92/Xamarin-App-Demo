using System;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace DemoApp.Base.Models
{
    public class Toast
    {
        /// <summary>
        /// Makes a standard toast with a text.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="duration">Duration in seconds.</param>
        public static void MakeText(string message, int duration)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ToastConfig.DefaultBackgroundColor = Color.FromHex("#3AB4D0");
                ToastConfig.DefaultMessageTextColor = Color.White;
                ToastConfig.DefaultActionTextColor = Color.White;

                var toastConfig = new ToastConfig(message);
                //.SetIcon("information_circle2.png");
                //.SetAction(x => x
                //.SetText("OK"));
                toastConfig.SetDuration(TimeSpan.FromSeconds(duration));
                UserDialogs.Instance.Toast(toastConfig);
            });
        }


        /// <summary>
        /// Makes a warning toast with a text.
        /// </summary>
        /// <param name="warningMessage">Message.</param>
        /// <param name="duration">Duration in seconds.</param>
        public static void MakeWarning(string warningMessage, int duration)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ToastConfig.DefaultBackgroundColor = Color.FromHex("#F2994A");
                ToastConfig.DefaultMessageTextColor = Color.White;
                ToastConfig.DefaultActionTextColor = Color.White;

                var toastConfig = new ToastConfig(warningMessage);
                //.SetIcon("information_circle2.png");
                //.SetAction(x => x
                //.SetText("OK"));
                toastConfig.SetDuration(TimeSpan.FromSeconds(duration));
                UserDialogs.Instance.Toast(toastConfig);
            });
        }
    }
}
