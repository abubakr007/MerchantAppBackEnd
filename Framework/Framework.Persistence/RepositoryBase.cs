using Framework.Core.Domain;
using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Framework.Persistence
{
    public class RepositoryBase<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot<TAggregateRoot>, IEntityBase, new()
    {
        protected readonly DbContextBase DbContext;


        protected RepositoryBase(IDbContext dbContext)
        {
            DbContext = (DbContextBase)dbContext;
        }


        protected virtual IQueryable<TAggregateRoot> Set
        {
            get
            {
                var set = DbContext.Set<TAggregateRoot>().AsQueryable();
                var includeExpressions = new TAggregateRoot().GetAggregateExpressions();
                foreach (var expression in includeExpressions)
                    if (expression != null)
                        set.Include(expression).Load();

                return set;
            }
        }


        protected void Create(TAggregateRoot aggregateRoot)
        {
            DbContext.Set<TAggregateRoot>().Add(aggregateRoot);
        }


        protected void Update(TAggregateRoot aggregateRoot)
        {
            DbContext.Entry(aggregateRoot).State = EntityState.Modified;
        }


        protected void Delete(TAggregateRoot aggregateRoot)
        {
            DbContext.Set<TAggregateRoot>().Remove(aggregateRoot);
        }
    }
}