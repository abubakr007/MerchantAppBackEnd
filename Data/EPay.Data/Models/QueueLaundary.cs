using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class QueueLaundary
    {
        public long Id { get; set; }
        public string? FromAddress { get; set; }
        public string? ToAddress { get; set; }
        public bool IsOnlinePayment { get; set; }

        public virtual QueueMaster IdNavigation { get; set; } = null!;
    }
}
