using Epay.QueueContext.Domain.Acl;
using Epay.QueueContext.Domain.Queues.Services;

namespace Epay.QueueContext.Domain.Services.Queues
{
    public class SmartCardDiscountGetter : ISmartCardDiscountGetter
    {
        private readonly ISmartCardAcl smartCardAcl;

        public SmartCardDiscountGetter(ISmartCardAcl smartCardAcl)
        {
            this.smartCardAcl = smartCardAcl;
        }
        public double? GetDiscount(string? cardNumber, string merchantCode)
        {
            if(cardNumber == null) return null;
            return smartCardAcl.GetSmartCardPercentageDiscount(cardNumber, merchantCode);
        }
    }
}
