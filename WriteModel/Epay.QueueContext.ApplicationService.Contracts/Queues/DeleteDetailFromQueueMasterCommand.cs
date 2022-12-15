using Framework.Core.Application;

namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class DeleteDetailFromQueueMasterCommand : Command
    {
        public long DetailId { get; set; }
        public int ProductId { get; set; }
        public int QueueMasterId { get; set; }
    }
}
