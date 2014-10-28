namespace NSBPerf.RoutingSlip.Producer
{
    using Initiator.Messages;
    using Messages;
    using NServiceBus;
    using NServiceBus.MessageRouting.RoutingSlips;

    public class InitiateHandler : IHandleMessages<Initiate>
    {
        public IBus Bus { get; set; }

        public void Handle(Initiate message)
        {
            Bus.Route(new DoWork { WorkId = message.CorrelationId}, new []
            {
                "NSBPerf.RoutingSlip.StepA",
                "NSBPerf.RoutingSlip.StepB",
                "NSBPerf.RoutingSlip.StepC",
                "NSBPerf.RoutingSlip.StepD",
                //"NSBPerf.RoutingSlip.Saga"
            });
        }
    }
}