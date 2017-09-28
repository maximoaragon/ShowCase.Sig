
namespace Exchange.Contracts
{
    public enum AsyncEvents
    {
        Unknown = 0,
        
        AsyncEventStarted = 1,
        AsyncEventCompleted = 2,
        AsyncEventStateChange = 3,
        AsyncEventProgressUpdate = 4,
        
        // States
        AsyncEventSuspend = 5,
        AsyncEventResume = 6,
        AsyncEventCancel = 7,
        AsyncEventTerminate = 8
    }
}
