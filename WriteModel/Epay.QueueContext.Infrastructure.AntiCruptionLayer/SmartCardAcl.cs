using Epay.QueueContext.Domain.Acl;
using Epay.ReadModel.Context;
using Framework.Core.DependencyInjection;

namespace Epay.QueueContext.Infrastructure.AntiCruptionLayer
{
    public class SmartCardAcl : ISmartCardAcl
    {
        private readonly IDiContainer container;

        public SmartCardAcl(IDiContainer container)
        {
            this.container = container;
        }
        public double? GetSmartCardPercentageDiscount(string smartCard, string merchantCode)
        {
            var db = container.Resolve<EpayContext>();
            return db.SmartCards
                .SingleOrDefault(x => 
                x.MerchantId == merchantCode &&
                x.CardNo == smartCard &&
                x.CardType.ToLower() == "d" &&
                x.CardStatus.ToLower() == "i" &&
                //DateTime.Now >= x.ActivationDate &&
                DateTime.Now <= x.ExpairyDate &&
                x.Status == true)?.DiscountPer;
        }
    }
}