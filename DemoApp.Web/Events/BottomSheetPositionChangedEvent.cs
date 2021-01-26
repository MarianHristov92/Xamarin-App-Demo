using System;
using EventBus.Interfaces;

namespace DemoAppBackendApi.Events
{
    public class BottomSheetPositionChangedEvent : IMessage
    {
        public bool isCollectionViewScrollable { get; set; }
        public bool IsOnMainThread { get; set; }
        public BottomSheetPositionChangedEvent(bool isScrollable, bool main)
        {
            isCollectionViewScrollable = isScrollable;
            IsOnMainThread = main;
        }

    }
}