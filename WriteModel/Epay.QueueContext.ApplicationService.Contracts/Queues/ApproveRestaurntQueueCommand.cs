using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class ApproveRestaurntQueueCommand:Command
    {
        public long QueueId { get; set; }
        public string? Param1 { get; set; }
        public string? Param2 { get; set; }
        public string? Param3 { get; set; }
        public string? MobileNumber { get; set; }
    }
}
