using System;
using Xamarin.Forms;

namespace DemoApp.Base.Models
{
    public class AttachedProperties
    {
        public static readonly BindableProperty AccessibilityChangeableFontSizeProperty =
            BindableProperty.CreateAttached("AccessibilityChangeableFontSize", typeof(bool), typeof(AttachedProperties), defaultValue: true);

        public static bool GetAccessibilityChangeableFontSize(BindableObject bo)
        {
            if (bo != null)
                return (bool)bo.GetValue(AccessibilityChangeableFontSizeProperty);
            else
                return true;
        }

        public static void SetAccessibilityChangeableFontSize(BindableObject bo, bool value)
        {
            bo.SetValue(AccessibilityChangeableFontSizeProperty, value);
        }

        public AttachedProperties()
        {
        }
    }
}
