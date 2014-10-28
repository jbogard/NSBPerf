namespace NSBPerf.Controller.Producer.Messages
{
    using NServiceBus;

    public class WorkReceived : IEvent
    {
        public int WorkId { get; set; }
    }
}