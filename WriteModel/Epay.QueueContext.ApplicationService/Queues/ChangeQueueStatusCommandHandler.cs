using Epay.Constants;
using Epay.QueueContext.ApplicationService.Contracts.Queues;
using Epay.QueueContext.Domain.Queues.Services;
using Framework.Core.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epay.QueueContext.ApplicationService.Queues
{
    public class ChangeQueueStatusCommandHandler : ICommandHandler<ChangeQueueStatusCommand>
    {
        private readonly IQueueRepository queueRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ChangeQueueStatusCommandHandler(IQueueRepository queueRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.queueRepository = queueRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public void Execute(ChangeQueueStatusCommand command)
        {
            var queue = queueRepository.GetQueueMasterById(command.QueueId);
            queue.SetStatus(command.QueueStatusId);
            queueRepository.UpdateQueue(queue);
        }
    }
}
