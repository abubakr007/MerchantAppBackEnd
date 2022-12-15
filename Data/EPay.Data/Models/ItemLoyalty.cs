using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class ItemLoyalty
    {
        public long Id { get; set; }
        public int GivingPoints { get; set; }
        public int DeductPoints { get; set; }
        public DateTime ExpirePeriod { get; set; }
        public bool AllowRecharge { get; set; }
        public bool IsDeal { get; set; }
        public long DealId { get; set; }
        public bool AllowCoupons { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Item IdNavigation { get; set; } = null!;
    }
}
