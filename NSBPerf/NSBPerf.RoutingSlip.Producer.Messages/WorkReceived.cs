namespace NSBPerf.RoutingSlip.Producer.Messages
{
    using System;
    using NServiceBus;

    public class DoWork : ICommand
    {
        public int WorkId { get; set; }
    }
}