using Epay.Constants;
using System.Collections.Generic;

namespace Epay.QueueContext.Domain.Contracts.Events
{
    public class QueueDetailDeletedEvent : NotificationEvent
    {
        public long DetailId { get; set; }
        public int ProductId { get; set; }
        public long QueueMasterId { get; set; }
        public int MerchantId { get; set; }
        public override string NotificationType => NotificationTypes.QueueDetailRemoved;

    }
}
