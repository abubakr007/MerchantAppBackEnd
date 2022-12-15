namespace Epay.QueueContext.Domain.Contracts.Events
{
    public class QueueDetailEvent
    {
        public long Id { get; set; }
        public long QueueMasterId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double OpenPrice { get; set; }
        public int? WorkerId { get; set; }
        public double Tax { get; set; }
    }


}
