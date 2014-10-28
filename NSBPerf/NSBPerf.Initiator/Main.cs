namespace NSBPerf.Initiator
{
    using Messages;
    using NServiceBus;

    internal static class Blarg
    {
        private static void Main(string[] args)
        {
            var config = new BusConfiguration();
            config.UsePersistence<InMemoryPersistence>();

            var bus = Bus.CreateSendOnly(config);

            for (int i = 0; i < 10000; i++)
            {
                //bus.Send("NSBPerf.Observer.Producer", new Initiate {CorrelationId = i});
                bus.Send("NSBPerf.Controller.Producer", new Initiate {CorrelationId = i});
                //bus.Send("NSBPerf.RoutingSlip.Producer", new Initiate {CorrelationId = i});
            }
        }
    }
}