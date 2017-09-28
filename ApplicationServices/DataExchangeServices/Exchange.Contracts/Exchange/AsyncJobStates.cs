
namespace Exchange.Contracts
{
    public enum AsyncJobStates
    {
        JobStateUnknown = 0,
        JobStateReady = 1,
        JobStateExecuting = 2,
        JobStateSuspended = 3,
        JobStateStopped = 4,
        JobStateComplted = 5,
        JobStateExceptionQueue = 6
    }
}
