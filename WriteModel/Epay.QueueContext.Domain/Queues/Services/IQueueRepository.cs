using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.QueueContext.Domain.Queues.Services
{
    public interface IQueueRepository
    {
        void Create(QueueMaster queue);
        QueueMaster GetQueueMasterById(long QueueMasterId);
        void UpdateQueue(QueueMaster queue);
        void Remove(long queueMasterId);
        long GetLatestToken(int merchantId);
        IList<QueueMaster> GetQueueMastersByIds(IList<long> queueIds);
        int GetNextStatusForStatus(int queueStatusId);
        void InsertDetails(List<QueueDetail> details);
        void UpdateQueueDetail(QueueDetail queueDetail);
    }
}
