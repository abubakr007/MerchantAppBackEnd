using Epay.Constants;
using System.Collections.Generic;

namespace Epay.QueueContext.Domain.Contracts.Events
{
    public class QueueDetailAddedEvent :NotificationEvent
    {
        public long QueueMasterId { get; set; }
       
        public int MerchantId { get; set; }
        public double TotalAmount { get; set; }
        public IList<QueueDetailEvent> QueueDetails { get; set; } = null!;
        public override string NotificationType=> NotificationTypes.NewDetailAdded;




    }
}
