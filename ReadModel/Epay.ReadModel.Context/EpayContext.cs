using EPay.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Epay.ReadModel.Context
{
    public class EpayContext : EpDbContext
    {
        public EpayContext(DbContextOptions options) : base(options)
        {
        }
    }
}