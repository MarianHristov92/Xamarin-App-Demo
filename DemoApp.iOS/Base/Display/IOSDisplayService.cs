using System;
using DemoApp.Base.Display;
using DemoApp.iOS.Base.Display;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(iOSDisplayService))]
namespace DemoApp.iOS.Base.Display
{
    public class iOSDisplayService : IDisplayService
    {
        private static float? _lastBrightness = null;

        public void ResetBrightness()
        {
            if (_lastBrightness != null)
            {
                UIScreen.MainScreen.Brightness = (float)_lastBrightness;

                _lastBrightness = null;
            }
        }

        public void SetBrightness(float factor)
        {
            if (_lastBrightness == null)
                _lastBrightness = (float)UIScreen.MainScreen.Brightness;

            UIScreen.MainScreen.Brightness = factor;
        }
    }
}
