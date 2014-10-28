
namespace NSBPerf.RoutingSlip.StepC
{
    using System.Threading;
    using NServiceBus;
    using NServiceBus.MessageRouting.RoutingSlips;
    using Producer.Messages;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.RoutingSlips();
        }
    }

    public class DoWorkHandler : IHandleMessages<DoWork>
    {
        public IBus Bus { get; set; }
        public void Handle(DoWork message)
        {
            //Thread.Sleep(150);
        }
    }
}
