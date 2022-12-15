using Epay.QueueContext.Domain.Tables;

namespace Epay.QueueContext.Domain.Queues
{
    public class QueueRestaurant
    {
        public QueueRestaurant(int? tableId)
        {
            TableId = tableId;
        }
        public long Id { get; set; }
        public int? TableId { get; set; }

        public virtual QueueMaster IdNavigation { get; set; } = null!;
        public virtual Table Table { get; set; } = null!;
    }
}
