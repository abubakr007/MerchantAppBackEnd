using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.ProductContext.Domain.Products.Services
{
    public interface IProductRepository
    {
        
        Product GetProductById(int productId);
        void UpdateProduct(Product product);
        PriceGroupDetail GetPriceGroupDetail(int priceGroupId, int productId);
        void UpdatePriceGroupDetail(PriceGroupDetail priceGroupDetail);
    }
}
