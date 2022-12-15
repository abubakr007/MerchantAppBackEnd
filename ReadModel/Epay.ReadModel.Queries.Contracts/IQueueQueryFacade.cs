using Epay.ReadModel.Queries.Contracts.Dto;
using Framework.Filtering;
using System.Collections.Generic;

namespace Epay.ReadModel.Queries.Contracts
{
    public interface IQueueQueryFacade
    {
        IList<QueueMasterDto> GetAllQueues();
        QueryResult<QueueMasterDto> GetQueues(QueryFilter filters);
        QueueMasterDto GetQueueByNumber(int number);
        QueueMasterDto GetQueueById(long id);
        IList<long> GetAllQueuesId();
        IList<QueueStatusDto> GetAllQueueStatus();
        QueryResult<QueueMasterDto> GetAllQueuesByStatusId(long statusId, QueryFilter filters);
        QueryResult<QueueMasterDto> GetAllOpenedQueues(QueryFilter filters);
    }
}
