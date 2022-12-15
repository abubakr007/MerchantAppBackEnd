using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Items = new HashSet<Item>();
        }

        public long Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameFr { get; set; }
        public string? NameTr { get; set; }
        public string? NameUr { get; set; }
        public long? ImageId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public long CategoryId { get; set; }
        public int Sort { get; set; }
        public long ItemListId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Item> Items { get; set; }
    }
}
