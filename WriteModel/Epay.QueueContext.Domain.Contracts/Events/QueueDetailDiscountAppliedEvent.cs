namespace Epay.QueueContext.Domain.Contracts.Events
{
    public class QueueDetailDiscountAppliedEvent 
    {

        public long Id { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double OpenPrice { get; set; }
        public double Tax { get; set; }
        public double OrginalPrice { get; set; }

    }
}
