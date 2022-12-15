namespace Epay.QueueContext.Domain.Queues
{
    public class QueueLaundary
    {

        public QueueLaundary(string? fromAddress, string? toAddress, bool isOnlinePayment)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
            IsOnlinePayment = isOnlinePayment;
        }

        public long Id { get; set; }
        public string? FromAddress { get; set; }
        public string? ToAddress { get; set; }
        public bool IsOnlinePayment { get; set; }

        public virtual QueueMaster IdNavigation { get; set; } = null!;
    }
}
