using System;
using EventBus.Interfaces;

namespace DemoAppBackendApi.Events
{
    public class PasswordRecoveryFailedEvent : IMessage
    {
        public bool IsOnMainThread { get; set; }

        public PasswordRecoveryFailedEvent(bool main)
        {
            IsOnMainThread = main;
        }
    }
}