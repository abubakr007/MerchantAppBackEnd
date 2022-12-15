using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class ItemPrice
    {
        public long Id { get; set; }
        public double? BuyingPrice { get; set; }
        public double SellingPrice { get; set; }
        public double DiscountRange { get; set; }
        public bool IsOpenPrice { get; set; }
        public bool IsOpenQuantity { get; set; }
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Item IdNavigation { get; set; } = null!;
    }
}
