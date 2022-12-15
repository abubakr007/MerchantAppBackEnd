using Framework.Core.Domain;

namespace Epay.QueueContext.Domain.Queues.Services
{
    public interface ISmartCardDiscountGetter : IDomainService
    {
        double? GetDiscount(string? cardNumber, string merchantCode);
    }
}
