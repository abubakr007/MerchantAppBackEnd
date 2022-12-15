using Epay.ProductContext.Domain.Acl;
using Framework.Core.DependencyInjection;
using Framework.Core.Mapper;
using Epay.ReadModel.Context;

namespace Epay.ProductContext.Infrastructure.AntiCruptionLayer
{
    public class MerchantAcl : IMerchantAcl
    {
        private readonly IDiContainer container;
        private readonly IMapper mapper;

        public MerchantAcl(IDiContainer container, IMapper mapper)
        {
            this.container = container;
            this.mapper = mapper;
        }
        public int GetPricingGroupId(string merchantId)
        {
            var db = container.Resolve<EpayContext>();
            return db.Merchants.Single(p => p.MerchantId == merchantId).PricingGroupId??0;
        }
    }
}