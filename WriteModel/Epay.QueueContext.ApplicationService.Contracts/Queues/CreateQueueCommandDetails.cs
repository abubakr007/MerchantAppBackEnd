namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class CreateQueueCommandDetails
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double OpenPrice { get; set; }
        public bool? IsHang { get; set; }
        public int? WorkerId { get; set; }
    }
}
