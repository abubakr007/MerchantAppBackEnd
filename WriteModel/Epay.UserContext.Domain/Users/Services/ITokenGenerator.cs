using Framework.Core.Domain;

namespace Epay.UserContext.Domain.Users.Services
{
    public interface ITokenGenerator : IDomainService
    {
        string AccessTokenGenerator(string userName, string merchantNumber, int businessTypeId, int merchantId);
        string AccessTokenGeneratorForAspUser(string userName, string userLevel, string merchantId);
    }
}
