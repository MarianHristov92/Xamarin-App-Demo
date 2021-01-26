using System;
using Xamarin.Forms;

namespace DemoApp.Base.Display
{
    public static class CrossDisplayService
    {
        public static void ResetBrightness()
        {
            var service = DependencyService.Get<IDisplayService>();
            service.ResetBrightness();
        }

        public static void SetBrightness(float factor)
        {
            var service = DependencyService.Get<IDisplayService>();
            service.SetBrightness(factor);
        }
    }
}
