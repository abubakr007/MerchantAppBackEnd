using Framework.Core.Application;

namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class DeleteQueueCommand : Command
    {
        public long QueueMasterId { get; set; }
    }
}
