using Epay.Constants;
using System.Collections.Generic;

namespace Epay.QueueContext.Domain.Contracts.Events
{
    public class QueueCreatedEvent : NotificationEvent
    {
        public long TokenNumber { get; set; }
        public long Id { get; set; }
        public IList<QueueDetailEvent> Detail { get; set; }

        public override string NotificationType => NotificationTypes.QueueCreated;
    }
}
