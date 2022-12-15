namespace Epay.UserContext.Domain.Users.Services
{
    public interface IUserRepository
    {
        User GetUser(string posSerialNumber, string terminalId, string password);
        AspNetUser GetAspNetUserByUserName(string userName);
    }
}
