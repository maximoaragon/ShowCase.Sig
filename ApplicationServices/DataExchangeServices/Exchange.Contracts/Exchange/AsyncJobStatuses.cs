
namespace Exchange.Contracts
{
    public enum AsyncJobStatuses
    {
        JobStatusUnknown = 0,
        JobStatusStoppedCancelled = 1,
        JobStatusStoppedException = 2,
        JobStatusCompltedNormal = 3,
        JobStatusCompltedTerminated = 4,
        JobStatusExecuting = 5,
        JobStatusSuspended = 6,
        JobStatusReady = 7
    }
}
