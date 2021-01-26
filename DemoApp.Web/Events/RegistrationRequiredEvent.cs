using System;
using EventBus.Interfaces;

namespace DemoAppBackendApi.Events
{
    public class RegistrationRequiredEvent : IMessage
    {
        public string Description { get; set; }
        public bool IsOnMainThread { get; set; }

        public RegistrationRequiredEvent(string desc, bool main)
        {
            Description = desc;
            IsOnMainThread = main;
        }
    }
}
