using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            QueueDetails = new HashSet<QueueDetail>();
        }

        public int Id { get; set; }
        public int ProviderId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductNameEng { get; set; }
        public string? ProductNameAr { get; set; }
        public string? PosprintProductName { get; set; }
        public string Currency { get; set; } = null!;
        public DateTime? ValiditydateStart { get; set; }
        public DateTime? ValiditydateEnd { get; set; }
        public string? FaceValue { get; set; }
        public string? BuyingPrice { get; set; }
        public string Eantype { get; set; } = null!;
        public string Eancode { get; set; } = null!;
        public string? InternalReference { get; set; }
        public int TicketLayoutId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool? Status { get; set; }
        public int? LoyaltyPoints { get; set; }
        public string? Points { get; set; }
        public int? QgroupId { get; set; }
        public double? Quantity { get; set; }
        public long? LogoId { get; set; }
        public bool? IsOpenPrice { get; set; }
        public string? ProductType { get; set; }
        public int? ServiceDuration { get; set; }
        public string? ProductNameTurki { get; set; }

        public virtual ICollection<QueueDetail> QueueDetails { get; set; }
    }
}
