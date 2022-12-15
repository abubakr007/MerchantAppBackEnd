using Epay.QueueContext.Domain.Acl.Dto;
using Framework.Core.Domain;

namespace Epay.QueueContext.Domain.Queues.Services
{
    public interface IMerchantSettingAccessor : IDomainService
    {
        bool IsApprovalNeededForInsideCustomerQueue(int merchantId);
        bool IsApprovalNeededForOutsideCustomerQueue(int merchantId);
        bool IsApprovalNeededForWaiterQueue(int merchantId);

        TaxSettingDto GetTaxSettingForMerchant(int merchantId);
    }
}
