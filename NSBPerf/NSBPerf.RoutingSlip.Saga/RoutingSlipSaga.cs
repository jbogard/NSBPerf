namespace NSBPerf.RoutingSlip.Saga
{
    using System;
    using NServiceBus.Saga;
    using StepA.Messages;
    using StepD.Messages;

    public class RoutingSlipData : ContainSagaData
    {
        public virtual int WorkId { get; set; }
        public virtual DateTime? StartTime { get; set; }
        public virtual DateTime? EndTime { get; set; }
    }

    public class RoutingSlipSaga : Saga<RoutingSlipData>,
        IAmStartedByMessages<WorkStarted>,
        IAmStartedByMessages<WorkCompleted>
    {
        public NServiceBus.MessageRouting.RoutingSlips.RoutingSlip Slip { get; set; }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<RoutingSlipData> mapper)
        {
            mapper.ConfigureMapping<WorkStarted>(m => m.WorkId).ToSaga(s => s.WorkId);
            mapper.ConfigureMapping<WorkCompleted>(m => m.WorkId).ToSaga(s => s.WorkId);
        }

        public void Handle(WorkStarted message)
        {
            Data.StartTime = message.StartTime;
            Data.WorkId = message.WorkId;
        }

        public void Handle(WorkCompleted message)
        {
            Data.EndTime = message.EndTime;

            Data.WorkId = message.WorkId;
        }
    }
}