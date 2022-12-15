namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class QueueRestaurantDto
    {
        public long Id { get; set; }
        public int TableId { get; set; }

        public QueueMasterDto IdNavigation { get; set; } = null!;
        public TableDto Table { get; set; } = null!;
    }
}
