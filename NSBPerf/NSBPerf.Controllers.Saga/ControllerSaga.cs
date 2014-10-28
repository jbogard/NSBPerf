namespace NSBPerf.Controller.Saga
{
    using System;
    using NServiceBus;
    using NServiceBus.Saga;
    using Producer.Messages;
    using StepA.Messages;
    using StepB.Messages;
    using StepC.Messages;
    using StepD.Messages;

    public class ControllerData : ContainSagaData
    {
        public virtual int WorkId { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime? EndTime { get; set; }
    }

    public class ControllerSaga : Saga<ControllerData>,
        IAmStartedByMessages<WorkReceived>,
        IHandleMessages<StepADone>,
        IHandleMessages<StepBDone>,
        IHandleMessages<StepCDone>,
        IHandleMessages<StepDDone>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ControllerData> mapper)
        {
            
        }

        public void Handle(WorkReceived message)
        {
            Data.WorkId = message.WorkId;
            Data.StartTime = DateTime.Now;

            Bus.Send(new DoStepA());
        }

        public void Handle(StepADone message)
        {
            Bus.Send(new DoStepB());
        }

        public void Handle(StepBDone message)
        {
            Bus.Send(new DoStepC());
        }

        public void Handle(StepCDone message)
        {
            Bus.Send(new DoStepD());
        }

        public void Handle(StepDDone message)
        {
            Data.EndTime = DateTime.Now;
        }
    }
}