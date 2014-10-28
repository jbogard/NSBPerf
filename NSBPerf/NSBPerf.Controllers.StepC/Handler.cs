namespace NSBPerf.Controller.StepC
{
    using System.Threading;
    using Messages;
    using NServiceBus;

    public class Handler : IHandleMessages<DoStepC>
    {
        public IBus Bus { get; set; }
        public void Handle(DoStepC message)
        {
            //Thread.Sleep(150);
            Bus.Reply(new StepCDone());
        }
    }
}