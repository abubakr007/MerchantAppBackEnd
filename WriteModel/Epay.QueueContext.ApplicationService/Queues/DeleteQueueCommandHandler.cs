using Epay.QueueContext.ApplicationService.Contracts.Queues;
using Epay.QueueContext.Domain.Contracts.Events;
using Epay.QueueContext.Domain.Queues.Services;
using Framework.Core.Application;
using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.QueueContext.ApplicationService.Queues
{
    public class DeleteQueueCommandHandler : ICommandHandler<DeleteQueueCommand>
    {
        private readonly IQueueRepository queueRepository;
        private readonly IEventBus eventBus;

        public DeleteQueueCommandHandler(IQueueRepository queueRepository, IEventBus eventBus)
        {
            this.queueRepository = queueRepository;
            this.eventBus = eventBus;
        }

        public void Execute(DeleteQueueCommand command)
        {
            var MerchantId = queueRepository.GetQueueMasterById(command.QueueMasterId).MerchantId;
            queueRepository.Remove(command.QueueMasterId);
            eventBus.Publish(new QueueDeletedEvent { QueueMasterId=command.QueueMasterId, MerchantId= MerchantId });

        }
    }
}
