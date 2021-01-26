using System;
using EventBus.Interfaces;

namespace DemoAppBackendApi.Events
{
    public class LoginFailedEvent : IMessage
    {
        public bool IsOnMainThread { get; set; }
        public LoginFailedEvent(bool mainThread)
        {
            IsOnMainThread = mainThread;
        }
    }
}
