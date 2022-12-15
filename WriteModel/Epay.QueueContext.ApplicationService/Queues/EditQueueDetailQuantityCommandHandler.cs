using Epay.Constants;
using Epay.QueueContext.ApplicationService.Contracts.Queues;
using Epay.QueueContext.Domain.Contracts.Events;
using Epay.QueueContext.Domain.Queues.Services;
using Framework.Core.Application;
using Framework.Core.Domain;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Epay.QueueContext.ApplicationService.Queues
{
    public class EditQueueDetailQuantityCommandHandler : ICommandHandler<EditQueueDetailQuantityCommand>
    {
        private readonly IQueueRepository queueRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IEventBus eventBus;

        public EditQueueDetailQuantityCommandHandler(IQueueRepository queueRepository, IHttpContextAccessor httpContextAccessor, IEventBus eventBus)
        {
            this.queueRepository = queueRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.eventBus = eventBus;
        }
        public void Execute(EditQueueDetailQuantityCommand command)
        {
            var userId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.Cashier)?.Value ?? "0");
            var queue = queueRepository.GetQueueMasterById(command.QueueMasterId);
           
            queue.UpdateDetailCount(command.DetailId, command.NewQuantity);
            queueRepository.UpdateQueue(queue);
            queueRepository.UpdateQueueDetail(queue.QueueDetails.Single(x => x.Id == command.DetailId));
            eventBus.Publish(new QueueDetailEditedQuantityEvent
            {  QueueMasterId=command.QueueMasterId, DetailId=command.DetailId, NewQuantity=command.NewQuantity, MerchantId = queue.MerchantId });

        }
    }
}
