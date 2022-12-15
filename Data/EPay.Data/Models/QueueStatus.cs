using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class QueueStatus
    {
        public QueueStatus()
        {
            QueueMasters = new HashSet<QueueMaster>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int BusinessTypeId { get; set; }
        public int NextStatus { get; set; }

        public virtual ICollection<QueueMaster> QueueMasters { get; set; }
    }
}
