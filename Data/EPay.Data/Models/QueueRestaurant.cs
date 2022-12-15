using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class QueueRestaurant
    {
        public long Id { get; set; }
        public int? TableId { get; set; }

        public virtual QueueMaster IdNavigation { get; set; } = null!;
        public virtual Table? Table { get; set; }
    }
}
