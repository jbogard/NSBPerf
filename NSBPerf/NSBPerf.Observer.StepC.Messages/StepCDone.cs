namespace NSBPerf.Observer.StepC.Messages
{
    using NServiceBus;

    public class StepCDone : IEvent
    {
        public int WorkId { get; set; } 
    }
}