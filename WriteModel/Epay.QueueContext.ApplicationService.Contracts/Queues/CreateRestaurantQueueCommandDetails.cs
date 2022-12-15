namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class CreateRestaurantQueueCommandDetails
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double OpenPrice { get; set; }
        public int? WorkerId { get; set; }
    }

}
