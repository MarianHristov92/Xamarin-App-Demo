using System;
namespace DemoApp.Base.Display
{
    public interface IDisplayService
    {
        void SetBrightness(float factor);

        void ResetBrightness();
    }
}
