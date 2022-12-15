using Epay.QueueContext.ApplicationService.Contracts.Queues;
using Epay.QueueContext.Domain.Queues;
using Epay.QueueContext.Domain.Queues.Services;
using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.QueueContext.ApplicationService.Queues
{
    public class GenerateInvoiceForQueuesCommandHandler : ICommandHandler<GenerateInvoiceForQueuesCommand>
    {
        private readonly IQueueRepository queueRepository;

        public GenerateInvoiceForQueuesCommandHandler(IQueueRepository queueRepository)
        {
            this.queueRepository = queueRepository;
        }
        public void Execute(GenerateInvoiceForQueuesCommand command)
        {
            IList<QueueMaster> queues = queueRepository.GetQueueMastersByIds(command.QueueIds);

        }
    }
}
