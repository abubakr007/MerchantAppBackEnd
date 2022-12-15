using Framework.Core.Application;

namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class ChangeQueueStatusCommand : Command
    {
        public long QueueId { get; set; }
        public int QueueStatusId { get; set; }
    }
}
