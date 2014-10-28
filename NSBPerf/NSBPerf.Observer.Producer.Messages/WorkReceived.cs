namespace NSBPerf.Observer.Producer.Messages
{
    using NServiceBus;

    public class WorkReceived : IEvent
    {
        public int WorkId { get; set; }
    }
}