using Epay.UserContext.Domain.Users;
using Epay.UserContext.Domain.Users.Services;
using Framework.Core.Mapper;
using Framework.Core.Persistence;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Epay.UserContext.Infrastructure
{
    public class UserRepository : DbFirstRepositoryBase, IUserRepository
    {
        public UserRepository(IMapper mapper, IDbContext dbContext) : base(mapper, dbContext)
        {
        }

      

        public User GetUser(string posSerialNumber, string terminalId, string password)
        {
            var user = DbContext.Set<EPay.Data.Models.User>().FromSqlRaw("EXEC [AO].[LoginUser]").AsEnumerable()
                .FirstOrDefault(x => x.PosSerialNumber == posSerialNumber && x.TerminalId == terminalId && x.Password == password && !x.IsLocked);

            return Mapper.Map<User, EPay.Data.Models.User>(user);
        }
        public AspNetUser GetAspNetUserByUserName(string userName)
        {
            var user = DbContext.Set<EPay.Data.Models.AspNetUser>().SingleOrDefault(x => x.UserName == userName);
            return Mapper.Map<Domain.Users.AspNetUser, EPay.Data.Models.AspNetUser>(user);
        }
    }
}