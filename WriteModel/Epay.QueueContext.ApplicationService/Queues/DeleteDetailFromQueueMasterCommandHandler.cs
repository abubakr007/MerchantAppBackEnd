using Epay.QueueContext.ApplicationService.Contracts.Queues;
using Epay.QueueContext.Domain.Contracts.Events;
using Epay.QueueContext.Domain.Queues.Services;
using Framework.Core.Application;
using Framework.Core.Domain;
using System.Linq;

namespace Epay.QueueContext.ApplicationService.Queues
{

    public class DeleteDetailFromQueueMasterCommandHandler : ICommandHandler<DeleteDetailFromQueueMasterCommand>
    {
        private readonly IQueueRepository queueRepository;
        private readonly IEventBus eventBus;

        public DeleteDetailFromQueueMasterCommandHandler(IQueueRepository queueRepository, IEventBus eventBus)
        {
            this.queueRepository = queueRepository;
            this.eventBus = eventBus;
        }
        public void Execute(DeleteDetailFromQueueMasterCommand command)
        {
            var queue = queueRepository.GetQueueMasterById(command.QueueMasterId);
            queue.RemoveDetail(command.DetailId);
            queueRepository.UpdateQueue(queue);
            queueRepository.UpdateQueueDetail(queue.QueueDetails.Single(x => x.Id == command.DetailId));

            eventBus.Publish(new QueueDetailDeletedEvent
            { QueueMasterId = command.QueueMasterId, DetailId = command.DetailId, ProductId=command.ProductId,  MerchantId = queue.MerchantId });
        }
    }
}
