using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EPay.Data.Models
{
    public partial class EpDbContext: IDbContext
    {
        public EpDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public void Migrate() => base.Database.Migrate();

        public virtual DbSet<User> Users { get; set; }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasNoKey();
            });
        }
    }
}
