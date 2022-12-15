using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class QueueDetail
    {
        public long Id { get; set; }
        public long QueueMasterId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double OpenPrice { get; set; }
        public bool? IsHang { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int? WorkerId { get; set; }
        public double Tax { get; set; }
        public double OrginalPrice { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual QueueMaster QueueMaster { get; set; } = null!;
    }
}
