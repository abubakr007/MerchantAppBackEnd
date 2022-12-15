using Framework.Core.Persistence;

namespace Framework.Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext dbContext;


        public UnitOfWork(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void Commit()
        {
            dbContext.SaveChanges();
        }


        public void Rollback()
        {
            dbContext.Dispose();
        }
    }
}