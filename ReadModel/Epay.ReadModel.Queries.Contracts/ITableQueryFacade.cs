using Epay.ReadModel.Queries.Contracts.Dto;
using System.Collections.Generic;

namespace Epay.ReadModel.Queries.Contracts
{
    public interface ITableQueryFacade
    {
        IList<TableDto> GetAllTable();
        QueueStatusDto GetTableLastStatus(long tableId);
        IList<QueueMasterDto> GetAllOngoingQueuesForTable(long tableId);
    }
}
