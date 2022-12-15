using Framework.Core.Acl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.ProductContext.Domain.Acl
{
    public interface IMerchantAcl :  IAntiCorruptionLayer
    {
        int GetPricingGroupId(string merchantId);
    }
}
