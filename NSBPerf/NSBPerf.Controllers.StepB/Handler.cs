namespace NSBPerf.Controller.StepB
{
    using System.Threading;
    using Messages;
    using NServiceBus;

    public class Handler : IHandleMessages<DoStepB>
    {
        public IBus Bus { get; set; }
        public void Handle(DoStepB message)
        {
            //Thread.Sleep(150);
            Bus.Reply(new StepBDone());
        }
    }
}