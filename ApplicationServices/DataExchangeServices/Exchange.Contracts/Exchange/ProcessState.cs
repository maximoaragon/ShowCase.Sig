using System.Runtime.Serialization;

namespace Exchange.Contracts
{
    [DataContract()]
    public enum ProcessState
    {
        [EnumMember]
        Unknown = 0,
        [EnumMember]
        FailedComplete = 1,
        [EnumMember]
        Terminated = 2,
        [EnumMember]
        TerminateAll = 3,
        [EnumMember]
        Cancel = 4,
        [EnumMember]
        StartPublishing = 5,
        [EnumMember]
        Publishing = 6,
        [EnumMember]
        ReadyForWorker = 7,
        [EnumMember]
        InProgress = 14,
        [EnumMember]
        Suspend = 15,
        [EnumMember]
        Resume = 16,
        [EnumMember]
        CompletedwithError = 17,
        [EnumMember]
        Completed = 18
    }

}
