using Framework.Core.Application;
using System.Collections.Generic;

namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class CreateOfflineGeneralQueuesCommand : Command
    {
        public int MerchantId { get; set; }
        public double TotalAmount { get; set; }
        public int OfflineTokenNumber { get; set; }
        public string? Param1 { get; set; }
        public string? Param2 { get; set; }
        public string? Param3 { get; set; }
        public string? CouponCode { get; set; }
        public string? NfcCardNumber { get; set; }
        public int? CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public string RequestedBy { get; set; }
        public List<CreateQueueCommandDetails> Details { get; set; }
    }
}
