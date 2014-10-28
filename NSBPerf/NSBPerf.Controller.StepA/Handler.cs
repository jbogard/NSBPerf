namespace NSBPerf.Controller.StepA
{
    using System.Threading;
    using Messages;
    using NServiceBus;

    public class Handler : IHandleMessages<DoStepA>
    {
        public IBus Bus { get; set; }
        public void Handle(DoStepA message)
        {
            //Thread.Sleep(150);
            Bus.Reply(new StepADone());
        }
    }
}