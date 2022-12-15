using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class Logo
    {
        public Logo()
        {
            PriceGroupDetails = new HashSet<PriceGroupDetail>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? PathLocation { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<PriceGroupDetail> PriceGroupDetails { get; set; }
    }
}
