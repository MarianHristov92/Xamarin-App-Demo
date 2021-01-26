using System;
using EventBus.Interfaces;

namespace DemoAppBackendApi.Events
{
    public class RegistrationCompletedEvent : IMessage
    {
        public string Description { get; set; }
        public bool IsOnMainThread { get; set; }

        public RegistrationCompletedEvent(string desc, bool main)
        {
            Description = desc;
            IsOnMainThread = main;
        }
    }
}
