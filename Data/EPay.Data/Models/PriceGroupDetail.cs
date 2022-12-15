using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class PriceGroupDetail
    {
        public int Id { get; set; }
        public int PriceGroupMasterId { get; set; }
        public int ProductId { get; set; }
        public string? ValueType { get; set; }
        public double Rate { get; set; }
        public double NetPrice { get; set; }
        public double BuyingPrice { get; set; }
        public double FaceValue { get; set; }
        public int? Points { get; set; }
        public double? LoyaltyPoints { get; set; }
        public int? TaxId { get; set; }
        public bool? IsOpenPrice { get; set; }
        public bool? CouponAllowed { get; set; }
        public bool? RechargeNfc { get; set; }
        public bool? IsOpenQuantity { get; set; }
        public bool? IsDeal { get; set; }
        public long? DealId { get; set; }
        public long? LogoId { get; set; }
        public long? ProviderLogoId { get; set; }
        public bool? IsProductParam1 { get; set; }
        public double MaximumPrice { get; set; }
        public double MinimumPrice { get; set; }
        public bool? FastPrint { get; set; }
        public bool? IsSupervisorApprovalRequired { get; set; }
        public double MobileAppPrice { get; set; }
        public bool? IsMobilePriceVisible { get; set; }
        public bool Status { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public int? Order { get; set; }

        public virtual Logo? Logo { get; set; }
    }
}
