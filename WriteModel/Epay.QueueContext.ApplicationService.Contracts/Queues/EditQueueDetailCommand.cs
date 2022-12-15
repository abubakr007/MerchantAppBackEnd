using Framework.Core.Application;

namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class EditQueueDetailQuantityCommand : Command
    {
        public long QueueMasterId { get; set; }
        public long DetailId { get; set; }
        public double NewQuantity { get; set; }
    }
}
