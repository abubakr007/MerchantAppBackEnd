using System.Collections.Generic;

namespace Epay.QueueContext.Domain.Queues
{
    public class QueueStatus
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BusinessTypeId { get; set; }
        public int NextStatus { get; set; }

        public virtual ICollection<QueueMaster> QueueMasters { get; set; }
    }
}
