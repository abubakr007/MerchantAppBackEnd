using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class ItemList
    {
        public ItemList()
        {
            Items = new HashSet<Item>();
            Merchants = new HashSet<Merchant>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public long? MrchantParentId { get; set; }
        public long? CurrentPricingGroupId { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Merchant> Merchants { get; set; }
    }
}
