
namespace NSBPerf.RoutingSlip.Producer
{
    using NServiceBus;
    using NServiceBus.MessageRouting.RoutingSlips;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.RoutingSlips();
            configuration.UsePersistence<NHibernatePersistence>();
        }
    }
}
