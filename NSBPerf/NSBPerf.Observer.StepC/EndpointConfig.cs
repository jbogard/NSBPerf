
namespace NSBPerf.Observer.StepC
{
    using System.Threading;
    using Messages;
    using NServiceBus;
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
        }
    }

    public class WorkReceivedHandler : IHandleMessages<WorkReceived>
    {
        public IBus Bus { get; set; }
        public void Handle(WorkReceived message)
        {
            //Thread.Sleep(150);
            Bus.Publish(new StepCDone { WorkId = message.WorkId });
        }
    }
}
