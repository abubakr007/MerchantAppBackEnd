using Epay.QueueContext.Domain.Queues;
using Epay.QueueContext.Domain.Queues.Services;
using Framework.Core.Mapper;
using Framework.Core.Persistence;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Epay.QueueContext.Infrastructure.Persistence
{
    public class QueueRepository : DbFirstRepositoryBase, IQueueRepository
    {

        public QueueRepository(IMapper mapper, IDbContext dbContext) : base(mapper, dbContext)
        {
        }

        public void Create(QueueMaster queue)
        {
            var dbQueue = Mapper.Map<EPay.Data.Models.QueueMaster, QueueMaster>(queue);
            DbContext.Set<EPay.Data.Models.QueueMaster>().Add(dbQueue);
        }

        public QueueMaster GetQueueMasterById(long QueueMasterId)
        {
            var queue = GetDatabaseQueueMaster(QueueMasterId);
            return Mapper.Map<QueueMaster, EPay.Data.Models.QueueMaster>(queue);
        }

        private EPay.Data.Models.QueueMaster GetDatabaseQueueMaster(long QueueMasterId)
        {
            return DbContext.Set<EPay.Data.Models.QueueMaster>()
                .AsNoTracking()
                .Include(x => x.QueueDetails)
                .Include(x => x.QueueLaundary)
                .Include(x => x.QueueRestaurant)
                .Single(x => x.Id == QueueMasterId);
        }

        public void UpdateQueue(QueueMaster queue)
        {
            var dataBaseQueue = Mapper.Map<EPay.Data.Models.QueueMaster, QueueMaster>(queue);
            DbContext.Entry(dataBaseQueue).State = EntityState.Modified;
            DbContext.Set<EPay.Data.Models.QueueMaster>().Update(dataBaseQueue);
        }

        public void InsertDetails(List<QueueDetail> details)
        {
            var databaseDetails = Mapper.Map<EPay.Data.Models.QueueDetail, QueueDetail>(details);
            DbContext.Set<EPay.Data.Models.QueueDetail>().AddRange(databaseDetails);
        }
        public void UpdateQueueDetail(QueueDetail queueDetail)
        {
            var databaseDetail = Mapper.Map<EPay.Data.Models.QueueDetail, QueueDetail>(queueDetail);
            DbContext.Entry(databaseDetail).State = EntityState.Modified;
            DbContext.Set<EPay.Data.Models.QueueDetail>().Update(databaseDetail);
        }
        public void Remove(long queueMasterId)
        {
            var dataBaseQueue = DbContext.Set<EPay.Data.Models.QueueMaster>().Single(x => x.Id == queueMasterId);
            dataBaseQueue.IsDeleted = true;
            
        }

        public long GetLatestToken(int merchantId)
        {
            return (DbContext.Set<EPay.Data.Models.QueueMaster>()
                .Where(x => x.MerchantId == merchantId)
                .OrderByDescending(x => x.TokenNumber).FirstOrDefault()?.TokenNumber ?? 0);
        }

        public IList<QueueMaster> GetQueueMastersByIds(IList<long> queueIds)
        {
            var databaseQueues = DbContext.Set<EPay.Data.Models.QueueMaster>()
                .AsNoTracking()
                .Include(x => x.QueueDetails)
                .Include(x => x.QueueLaundary)
                .Include(x => x.QueueRestaurant)
                .Where(x => queueIds.Contains(x.Id)).ToList();
            return Mapper.Map<QueueMaster, EPay.Data.Models.QueueMaster>(databaseQueues);
        }

        public int GetNextStatusForStatus(int queueStatusId)
        {
            return DbContext.Set<QueueStatus>().Single(x => x.Id == queueStatusId).NextStatus;
        }

        
    }

}