using System;
using EventBus.Interfaces;

namespace DemoAppBackendApi.Events
{
    public class AppLifecycleEventStart : IMessage
    {
        public string Operation { get; set; }
        public bool IsOnMainThread { get; set; }

        public AppLifecycleEventStart(string operation, bool main)
        {
            Operation = operation;
            IsOnMainThread = main;
        }
    }

    public class AppLifecycleEventResume : AppLifecycleEventStart
    {
        public AppLifecycleEventResume(string operation, bool main) : base(operation, main)
        {
        }
    }

    public class AppLifecycleEventSleep : AppLifecycleEventStart
    {
        public AppLifecycleEventSleep(string operation, bool main) : base(operation, main)
        {
        }
    }

    public class AppLifecycleEventFinishedLaunching : AppLifecycleEventStart
    {
        public AppLifecycleEventFinishedLaunching(string operation, bool main) : base(operation, main)
        {
        }
    }
}
