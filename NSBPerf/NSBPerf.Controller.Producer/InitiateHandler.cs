namespace NSBPerf.Controller.Producer
{
    using Initiator.Messages;
    using Messages;
    using NServiceBus;

    public class InitiateHandler : IHandleMessages<Initiate>
    {
        public IBus Bus { get; set; }

        public void Handle(Initiate message)
        {
            Bus.Publish(new WorkReceived {WorkId = message.CorrelationId});
        }
    }
}