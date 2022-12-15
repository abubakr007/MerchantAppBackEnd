using Framework.Core.Mapper;
using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Framework.Persistence
{
    public class DbFirstRepositoryBase
    {
        public DbFirstRepositoryBase(IMapper mapper, IDbContext dbContext)
        {
            Mapper = mapper;
            DbContext = (DbContext)dbContext;
        }

        public IMapper Mapper { get; }
        public DbContext DbContext { get; }
    }
}
