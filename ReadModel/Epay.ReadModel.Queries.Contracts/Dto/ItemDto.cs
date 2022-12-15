using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class ItemDto
    {
        public long Id { get; set; }
        public NameDto Name { get; set; }
        public long? ImageId { get; set; }
        public int Sort { get; set; }
        public bool IsFastPrint { get; set; }
        public bool IsActive { get; set; }
        public string? Barcode { get; set; }
        public bool HasParam1 { get; set; }
        public bool IsSupervisorPassword { get; set; }
        public string? Description { get; set; }

        public virtual ItemLoyaltyDto ItemLoyalty { get; set; } = null!;
        public virtual ItemPriceDto ItemPrice { get; set; } = null!;
    }
}
