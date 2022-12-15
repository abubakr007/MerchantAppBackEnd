using Framework.Core.Application;
using System.Collections.Generic;

namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class GenerateInvoiceForQueuesCommand : Command
    {
        public IList<long> QueueIds { get; set; } = new List<long>();
    }
}
