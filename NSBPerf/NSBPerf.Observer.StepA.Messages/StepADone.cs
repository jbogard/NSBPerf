namespace NSBPerf.Observer.StepA.Messages
{
    using NServiceBus;

    public class StepADone : IEvent
    {
        public int WorkId { get; set; }
    }
}