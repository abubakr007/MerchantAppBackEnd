using Epay.QueueContext.Domain.Acl.Dto;
using Framework.Core.Acl;
using System.Collections.Generic;

namespace Epay.QueueContext.Domain.Acl
{
    public interface IProductAcl : IAntiCorruptionLayer
    {
        IList<ProductPriceAndTaxDto> GetProductsPriceAndTaxForMerchant(IList<int> ids, int merchantId);
        IList<ProductNameDto> GetProductName(IList<int> ids);
    }
}
