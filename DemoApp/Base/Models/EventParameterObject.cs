using System;
namespace DemoApp.Base.Models
{
    public class EventParameterObject
    {
        public object Sender { get; set; }
        public EventArgs Args { get; set; }

        public EventParameterObject(object sender, EventArgs eventArgs)
        {
            this.Sender = sender;
            this.Args = eventArgs;
        }
    }
}
