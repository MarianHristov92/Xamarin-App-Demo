using System;
using EventBus.Interfaces;

namespace DemoAppBackendApi.Events
{
    public class RegistrationFailedEvent : IMessage
    {
        public string Description { get; set; }
        public bool IsOnMainThread { get; set; }

        public RegistrationFailedEvent(string desc, bool main)
        {
            Description = desc;
            IsOnMainThread = main;
        }
    }
}