using System;

namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class QueueDetailDto
    {
        public long Id { get; set; }
        public long QueueMasterId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double OpenPrice { get; set; }
        public bool? IsHang { get; set; }
        public DateTime CreatedOn { get; set; }
        
        public int? WorkerId { get; set; }
        public double Tax { get; set; }
        public string? ProductNameEn { get; set; }
        public string? ProductNameAr { get; set; }
        public string? ProductNameTr { get; set; }

        public QueueMasterDto QueueMaster { get; set; } = null!;
    }
}
