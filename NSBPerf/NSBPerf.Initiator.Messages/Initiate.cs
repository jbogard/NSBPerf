namespace NSBPerf.Initiator.Messages
{
    using NServiceBus;

    public class Initiate : IMessage
    {
        public int CorrelationId { get; set; }
    }
}