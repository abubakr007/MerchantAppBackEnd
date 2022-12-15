using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Mapper;
using Framework.Core.Persistence;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Epay.CashierContext.Domain;
using EPay.Data.Models;

namespace Epay.CashierContext.Repository.Cashier
{
    public class CashierRepository : DbFirstRepositoryBase, ICashierRepository
    {
        public CashierRepository(IMapper mapper, IDbContext dbContext) : base(mapper, dbContext)
        {

        }
        public Domain.Cashier GetById(int id)
        {
            var cashier = DbContext.Set<EPay.Data.Models.Cashier>().AsNoTracking().Single(x => x.Id == id);
            return Mapper.Map<Domain.Cashier, EPay.Data.Models.Cashier>(cashier);
        }

        public void Create(Domain.Cashier cashier)
        {
            var dbCashier = Mapper.Map<EPay.Data.Models.Cashier, Domain.Cashier>(cashier);
            DbContext.Set<EPay.Data.Models.Cashier>().Add(dbCashier);
            DbContext.SaveChanges();
        }

        public void Update(Domain.Cashier cashier)
        {
            var dbCashier = Mapper.Map<EPay.Data.Models.Cashier, Domain.Cashier>(cashier);
            DbContext.Entry(dbCashier).State=EntityState.Modified;
            DbContext.Update(dbCashier);
            DbContext.SaveChanges();
        }
    }
}
