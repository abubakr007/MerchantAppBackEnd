using System;

namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class ItemLoyaltyDto
    {
        public int GivingPoints { get; set; }
        public int DeductPoints { get; set; }
        public DateTime ExpirePeriod { get; set; }
        public bool AllowRecharge { get; set; }
        public bool IsDeal { get; set; }
        public long DealId { get; set; }
        public bool AllowCoupons { get; set; }
    }
}
