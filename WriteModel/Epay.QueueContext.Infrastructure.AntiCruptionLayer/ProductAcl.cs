using Epay.QueueContext.Domain.Acl;
using Epay.QueueContext.Domain.Acl.Dto;
using Epay.ReadModel.Context;
using Framework.Core.DependencyInjection;

namespace Epay.QueueContext.Infrastructure.AntiCruptionLayer
{
    public class ProductAcl : IProductAcl
    {
        private readonly IDiContainer container;

        public ProductAcl(IDiContainer container)
        {
            this.container = container;
        }

        public IList<ProductPriceAndTaxDto> GetProductsPriceAndTaxForMerchant(IList<int> ids, int merchantId)
        {
            var db = container.Resolve<EpayContext>();
            var priceGroupId = db.Merchants.Single(p => p.Recid == merchantId).PricingGroupId;
            var taxes = db.Taxes.ToList();
            var res = db.PriceGroupDetails.Where(x => x.PriceGroupMasterId == priceGroupId && ids.Contains(x.ProductId)).Select(x => new { x.ProductId, x.FaceValue, x.TaxId}).ToList();
            return res.Select(p => new ProductPriceAndTaxDto { 
                Id = p.ProductId,
                Price = p.FaceValue,
                Tax = taxes.Single(x => x.Id == p.TaxId).Rate
            }).ToList();

        }

        public IList<ProductNameDto> GetProductName(IList<int> ids)
        {
            var db = container.Resolve<EpayContext>();

            return db.Products.Where(x => ids.Contains(x.Id)).Select(x => new ProductNameDto { Id = x.Id, Name = x.ProductNameEng }).ToList();
        }
    }
}