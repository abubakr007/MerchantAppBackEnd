using Epay.QueueContext.Domain.Acl;
using Epay.QueueContext.Domain.Acl.Dto;
using Epay.QueueContext.Domain.Queues.Services;

namespace Epay.QueueContext.Domain.Services.Queues
{
    public class MerchantSettingAccessor : IMerchantSettingAccessor
    {
        private readonly IMerchantAcl merchantAcl;

        public MerchantSettingAccessor(IMerchantAcl merchantAcl)
        {
            this.merchantAcl = merchantAcl;
        }

        public bool IsApprovalNeededForInsideCustomerQueue(int merchantId) => merchantAcl.IsApprovalNeededForInsideCustomer(merchantId);

        public bool IsApprovalNeededForOutsideCustomerQueue(int merchantId) => merchantAcl.IsApprovalNeededForOutsideCustomer(merchantId);

        public bool IsApprovalNeededForWaiterQueue(int merchantId) => merchantAcl.IsApprovalNeededForWaiter(merchantId);

        public TaxSettingDto GetTaxSettingForMerchant(int merchantId) 
        {
            var merchant = merchantAcl.GetMerchant(merchantId);
            return new TaxSettingDto
            {
                IsTaxAllowded = merchant?.TaxAllowed ?? false,
                IsTaxExcluded = merchant?.IsTaxExcluded ?? false,
                TaxAmount = (merchant?.TaxValue ?? 0) / 100.0
            };
        }
    }
}
