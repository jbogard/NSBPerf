namespace NSBPerf.Controller.StepD
{
    using System.Threading;
    using Messages;
    using NServiceBus;

    public class Handler : IHandleMessages<DoStepD>
    {
        public IBus Bus { get; set; }
        public void Handle(DoStepD message)
        {
            //Thread.Sleep(150);
            Bus.Reply(new StepDDone());
        }
    }
}