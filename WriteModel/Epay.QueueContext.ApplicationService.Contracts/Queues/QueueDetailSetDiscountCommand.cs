using Framework.Core.Application;

namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class QueueDetailSetDiscountCommand : Command
    {
        public long QueueMasterId { get; set; }
        public long DetailId { get; set; }
        public double DiscountAmount { get; set; }
    }
}
