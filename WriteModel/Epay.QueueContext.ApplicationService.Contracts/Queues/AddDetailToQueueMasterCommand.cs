using Framework.Core.Application;
using System.Collections.Generic;

namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class AddDetailToQueueMasterCommand : Command
    {
        public long QueueMasterId { get; set; }
        public double TotalAmount { get; set; }
        public IList<DetailForQueueMaster> DetailsForQueueMaster { get; set; } = null!;
    }
    public class DetailForQueueMaster
    {

        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double OpenPrice { get; set; }
        public bool? IsHang { get; set; }
        public int? WorkerId { get; set; }
    }
}
