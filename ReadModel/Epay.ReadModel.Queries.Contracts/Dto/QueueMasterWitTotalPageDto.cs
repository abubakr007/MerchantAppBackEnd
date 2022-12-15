using System.Collections.Generic;

namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class QueueMasterWitTotalPageDto
    {
        public int TotalPage { get; set; }
        public IList<QueueMasterDto> Queues { get; set; }
    }
}
