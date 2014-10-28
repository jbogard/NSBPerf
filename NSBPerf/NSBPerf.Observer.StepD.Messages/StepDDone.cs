namespace NSBPerf.Observer.StepD.Messages
{
    using NServiceBus;

    public class StepDDone : IEvent
    {
        public int WorkId { get; set; }
    }
}