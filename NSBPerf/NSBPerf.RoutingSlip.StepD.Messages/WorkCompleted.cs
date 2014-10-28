namespace NSBPerf.RoutingSlip.StepD.Messages
{
    using System;
    using NServiceBus;

    public class WorkCompleted : IEvent
    {
        public int WorkId { get; set; }
        public DateTime EndTime { get; set; }
    }
}