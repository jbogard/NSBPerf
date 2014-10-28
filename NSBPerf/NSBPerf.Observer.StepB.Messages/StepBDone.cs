namespace NSBPerf.Observer.StepB.Messages
{
    using NServiceBus;

    public class StepBDone : IEvent
    {
        public int WorkId { get; set; }
    }
}