using Epay.Constants;

namespace Epay.QueueContext.Domain.Contracts.Events
{
    public class QueueDeletedEvent:NotificationEvent
    {
        public int  MerchantId { get; set; }
        public long QueueMasterId { get; set; }
        public override string NotificationType =>NotificationTypes.QueueDeleted;

    }
}
