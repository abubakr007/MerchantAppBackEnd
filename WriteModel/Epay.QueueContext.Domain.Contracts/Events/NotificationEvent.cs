using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.QueueContext.Domain.Contracts.Events
{
    public abstract class NotificationEvent
    {
        public abstract string NotificationType { get; }
    }
}
