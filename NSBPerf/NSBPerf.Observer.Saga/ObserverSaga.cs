namespace NSBPerf.Observer.Saga
{
    using System;
    using NServiceBus.Saga;
    using StepA.Messages;
    using StepB.Messages;
    using StepC.Messages;
    using StepD.Messages;

    public class Data : ContainSagaData
    {
        [Unique]
        public virtual int WorkId { get; set; }
        public virtual bool StepADone { get; set; }
        public virtual bool StepBDone { get; set; }
        public virtual bool StepCDone { get; set; }
        public virtual bool StepDDone { get; set; }
        public virtual DateTime? StartTime { get; set; }
        public virtual DateTime? EndTime { get; set; }
    }

    public class ObserverSaga : Saga<Data>,
        IAmStartedByMessages<StepADone>,
        IAmStartedByMessages<StepBDone>,
        IAmStartedByMessages<StepCDone>,
        IAmStartedByMessages<StepDDone>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<Data> mapper)
        {
            mapper.ConfigureMapping<StepADone>(m => m.WorkId).ToSaga(s => s.WorkId);
            mapper.ConfigureMapping<StepBDone>(m => m.WorkId).ToSaga(s => s.WorkId);
            mapper.ConfigureMapping<StepCDone>(m => m.WorkId).ToSaga(s => s.WorkId);
            mapper.ConfigureMapping<StepDDone>(m => m.WorkId).ToSaga(s => s.WorkId);
        }

        public void Handle(StepADone message)
        {
            Data.StartTime = Data.StartTime ?? DateTime.Now;
            Data.WorkId = message.WorkId;
            Data.StepADone = true;
            CheckIfComplete();
        }

        public void Handle(StepBDone message)
        {
            Data.StartTime = Data.StartTime ?? DateTime.Now;
            Data.WorkId = message.WorkId;
            Data.StepBDone = true;
            CheckIfComplete();
        }

        public void Handle(StepCDone message)
        {
            Data.StartTime = Data.StartTime ?? DateTime.Now;
            Data.WorkId = message.WorkId;
            Data.StepCDone = true;
            CheckIfComplete();
        }

        public void Handle(StepDDone message)
        {
            Data.StartTime = Data.StartTime ?? DateTime.Now;
            Data.WorkId = message.WorkId;
            Data.StepDDone = true;
            CheckIfComplete();
        }

        private void CheckIfComplete()
        {
            if (Data.StepADone && Data.StepBDone && Data.StepCDone && Data.StepDDone)
            {
                Data.EndTime = DateTime.Now;
            }
        }
    }
}