
namespace Exchange.Contracts
{
    public enum AsyncCommands
    {
        Unknown = 0,
        AsyncSuspend = 1,
        AsyncResume = 2,
        AsyncCancel = 3,
        AsyncTerminate = 4,
        AsyncRetry = 5
    }
}
