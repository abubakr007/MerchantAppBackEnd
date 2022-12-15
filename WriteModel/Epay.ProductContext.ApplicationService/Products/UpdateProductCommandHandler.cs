using Epay.ProductContext.ApplicationService.Contracts.Products;
using Epay.ProductContext.Domain.Acl;
using Epay.ProductContext.Domain.Products.Services;

using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.ProductContext.ApplicationService.Products
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IProductRepository productRepository;
        private readonly IMerchantAcl merchantAcl;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMerchantAcl merchantAcl)
        {
            this.productRepository = productRepository;
            this.merchantAcl = merchantAcl;
        }
        public void Execute(UpdateProductCommand command)
        {
            var product = productRepository.GetProductById(command.ProductId);
            product.ProductNameEng = command.ProductName;
            product.Quantity = command.Quantity ??0;
            product.Status = command.Active ;
            product.LogoId= command.LogoId;
            productRepository.UpdateProduct(product);

            var priceGroupId = merchantAcl.GetPricingGroupId(command.MerchantId);
            var PriceGroupDetail= productRepository.GetPriceGroupDetail(priceGroupId, command.ProductId);
            PriceGroupDetail.BuyingPrice = command.Price;
            productRepository.UpdatePriceGroupDetail(PriceGroupDetail);


        }
    }
}
