namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class QueueLaundaryDto
    {
        public long Id { get; set; }
        public string? FromAddress { get; set; }
        public string? ToAddress { get; set; }
        public bool IsOnlinePayment { get; set; }

        public QueueMasterDto IdNavigation { get; set; } = null!;
    }
}
