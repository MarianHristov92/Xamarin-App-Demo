using System;
using EventBus.Interfaces;

namespace DemoAppBackendApi.Events
{
    public class PasswordRecoverySuccessfulEvent : IMessage
    {
        public bool IsOnMainThread { get; set; }

        public PasswordRecoverySuccessfulEvent(bool main)
        {
            IsOnMainThread = main;
        }
    }
}