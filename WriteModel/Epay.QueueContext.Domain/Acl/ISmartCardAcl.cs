using Framework.Core.Acl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.QueueContext.Domain.Acl
{
    public interface ISmartCardAcl : IAntiCorruptionLayer
    {
        double? GetSmartCardPercentageDiscount(string smartCard, string merchantCode);
    }
}
