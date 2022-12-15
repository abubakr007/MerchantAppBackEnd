using EPay.Data.Models;
using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Epay.Persistence
{
    public class EpayDbContext : EpDbContext
    {
        public EpayDbContext(DbContextOptions<EpayDbContext> options) : base(options)
        {

        }

    }
}