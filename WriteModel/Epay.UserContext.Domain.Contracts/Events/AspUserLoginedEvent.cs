using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.UserContext.Domain.Contracts.Events
{
    public class AspUserLoginedEvent
    {
        public string AccessToken { get; set; } = null!;
        public string MerchantId { get; set; } = null!;
        public string UserName { get; set; } = null!;
    }
}
