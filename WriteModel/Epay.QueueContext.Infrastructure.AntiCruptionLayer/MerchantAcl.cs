using Epay.QueueContext.Domain.Acl;
using Epay.QueueContext.Domain.Contracts.Acl;
using Epay.ReadModel.Context;
using EPay.Data.Models;
using Framework.Core.DependencyInjection;
using Framework.Core.Mapper;

namespace Epay.QueueContext.Infrastructure.AntiCruptionLayer
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

        public string GetMerchantCodeById(int id)
        {
            var db = container.Resolve<EpayContext>();
            return db.Merchants.Single(p => p.Recid == id).MerchantId;
        }

        public bool IsApprovalNeededForInsideCustomer(int id)
        {
            var db = container.Resolve<EpayContext>();
            return db.Merchants.Single(x => x.Recid == id).IsApproveNeedToInsideCustomer;
        }

        public bool IsApprovalNeededForOutsideCustomer(int id)
        {
            var db = container.Resolve<EpayContext>();
            return db.Merchants.Single(x => x.Recid == id).IsApproveNeedToOutsideCustomer;
        }

        public bool IsApprovalNeededForWaiter(int id)
        {
            var db = container.Resolve<EpayContext>();
            return db.Merchants.Single(x => x.Recid == id).IsApproveNeedToWaiter;
        }

        public MerchantDto GetMerchant(int merchantId)
        {
            var db = container.Resolve<EpayContext>();
            return mapper.Map<MerchantDto, Merchant>( db.Merchants.Single(x => x.Recid == merchantId));
        }
    }
}
