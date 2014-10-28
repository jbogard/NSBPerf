namespace NSBPerf.RoutingSlip.StepA.Messages
{
    using System;
    using NServiceBus;

    public class WorkStarted : IEvent
    {
        public int WorkId { get; set; }
        public DateTime StartTime { get; set; }
    }
}