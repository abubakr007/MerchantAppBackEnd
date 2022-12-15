using Epay.QueueContext.Domain.Contracts.Acl;
using Framework.Core.Acl;

namespace Epay.QueueContext.Domain.Acl
{
    public interface IMerchantAcl : IAntiCorruptionLayer
    {
        MerchantDto GetMerchant(int merchantId);
        string GetMerchantCodeById(int id);
        bool IsApprovalNeededForInsideCustomer(int id);
        bool IsApprovalNeededForOutsideCustomer(int id);
        bool IsApprovalNeededForWaiter(int id);
    }
}
