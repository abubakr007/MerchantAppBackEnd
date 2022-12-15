using Epay.QueueContext.Domain.Tables;
using Epay.QueueContext.Domain.Tables.Services;
using Framework.Core.Mapper;
using Framework.Core.Persistence;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Epay.QueueContext.Infrastructure.Persistence
{
    public class TableRepository : DbFirstRepositoryBase, ITableRepository
    {
        public TableRepository(IMapper mapper, IDbContext dbContext) : base(mapper, dbContext)
        {
        }

        public void Create(Table table)
        {
            var dbTable = Mapper.Map<EPay.Data.Models.Table, Table>(table);
            DbContext.Set<EPay.Data.Models.Table>().Add(dbTable);
        }


        public Table GetTableById(int tableId)
        {
            var table = DbContext.Set<EPay.Data.Models.Table>()
                .Single(x => x.Id == tableId);
            return Mapper.Map<Table, EPay.Data.Models.Table>(table);
        }

        public void Remove(int tableId)
        {
            var dataBaseQueue = DbContext.Set<EPay.Data.Models.Table>().Single(x => x.Id == tableId);
            dataBaseQueue.IsDeleted = true;
        }

        public void UpdateTable(Table table)
        {
            var dataBaseTable = Mapper.Map<EPay.Data.Models.Table, Table>(table);
            DbContext.Update(dataBaseTable);
        }

    }
}
