using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class Item
    {
        public long Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameFr { get; set; }
        public string? NameTr { get; set; }
        public string? NameUr { get; set; }
        public long? ImageId { get; set; }
        public bool IsFastPrint { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string? Barcode { get; set; }
        public long? OldId { get; set; }
        public long SubCategoryId { get; set; }
        public long ItemListId { get; set; }
        public int Sort { get; set; }
        public bool HasParam1 { get; set; }
        public bool IsSupervisorPassword { get; set; }
        public string? Description { get; set; }

        public virtual ItemList ItemList { get; set; } = null!;
        public virtual SubCategory SubCategory { get; set; } = null!;
        public virtual ItemLoyalty ItemLoyalty { get; set; } = null!;
        public virtual ItemPrice ItemPrice { get; set; } = null!;
    }
}
