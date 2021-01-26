using System;
using EventBus.Interfaces;

namespace DemoAppBackendApi.Events
{
    public class LoginCompleteEvent : IMessage
    {
        public bool IsOnMainThread { get; set; }

        public LoginCompleteEvent()
        {
        }
    }
}
