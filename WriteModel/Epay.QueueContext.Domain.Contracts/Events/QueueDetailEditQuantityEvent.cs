using Epay.Constants;

namespace Epay.QueueContext.Domain.Contracts.Events
{
    public class QueueDetailEditedQuantityEvent : NotificationEvent
    {

        public long QueueMasterId { get; set; }
        public long DetailId { get; set; }
        public double NewQuantity { get; set; }
        public int MerchantId { get; set; }
        public override string NotificationType => NotificationTypes.QuantityEdited;

    }
}
