namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class CreateOfflineLaundaryQueuesCommand : CreateOfflineGeneralQueuesCommand
    {
        public string? FromAddress { get; set; }
        public string? ToAddress { get; set; }
        public bool IsOnlinePayment { get; set; }
    }
}
