using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class SmartCard
    {
        public long CardId { get; set; }
        public string CardNo { get; set; } = null!;
        public long AccountNo { get; set; }
        public string CardType { get; set; } = null!;
        public string CardStatus { get; set; } = null!;
        public bool? Status { get; set; }
        public int? BusinessType { get; set; }
        public string? MerchantId { get; set; }
        public string? MerchantGroupId { get; set; }
        public DateTime? ActivationDate { get; set; }
        public DateTime? ExpairyDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public double? DiscountPer { get; set; }
        public int? MaxUsePerDay { get; set; }
        public long? CustomerId { get; set; }
        public long? DiscountCategoryId { get; set; }
        public string? TagUid { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
