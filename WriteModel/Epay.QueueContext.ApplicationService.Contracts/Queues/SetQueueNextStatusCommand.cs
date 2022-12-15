using Framework.Core.Application;

namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class SetQueueNextStatusCommand : Command
    {
        public long QueueId { get; set; }
    }
}
