using Epay.Constants;
using Epay.QueueContext.ApplicationService.Contracts.Queues;
using Epay.QueueContext.Domain.Queues.Services;
using Framework.Core.Application;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Epay.QueueContext.ApplicationService.Queues
{
    public class SetQueueNextStatusCommandHandler : ICommandHandler<SetQueueNextStatusCommand>
    {
        private readonly IQueueRepository queueRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        public SetQueueNextStatusCommandHandler(IQueueRepository queueRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.queueRepository = queueRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public void Execute(SetQueueNextStatusCommand command)
        {
            var queue = queueRepository.GetQueueMasterById(command.QueueId);
            int nextStatusId = queueRepository.GetNextStatusForStatus(queue.QueueStatusId);
            queue.SetStatus(nextStatusId);
            queueRepository.UpdateQueue(queue);
        }
    }
}
