using Framework.Core.Domain;

namespace Epay.QueueContext.Domain.Queues.Services
{
    public interface ITokenGenerator : IDomainService
    {
        long GetNewToken(int merchantId);
    }
}
