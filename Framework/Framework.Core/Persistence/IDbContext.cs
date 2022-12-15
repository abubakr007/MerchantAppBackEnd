using System;

namespace Framework.Core.Persistence
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
        void Migrate();
        new void Dispose();
    }
}