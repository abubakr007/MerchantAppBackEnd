using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Framework.Persistence
{
    public class DbContextBase : DbContext, IDbContext
    {
        public DbContextBase(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            Database.SetCommandTimeout(TimeSpan.FromSeconds(30));
        }

        public override int SaveChanges() => base.SaveChanges();

        public void Migrate() => base.Database.Migrate();

        public override void Dispose() => base.Dispose();
    }
}