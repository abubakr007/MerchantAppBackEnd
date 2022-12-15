using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class Batch
    {
        public long Id { get; set; }
        public string? BatchNo { get; set; }
        public int ProductId { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string? Barcode { get; set; }
        public string? PartNo { get; set; }
        public string? Narration { get; set; }
        public bool? IsActive { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public string? MerchantId { get; set; }
        public string? MerchantGroupId { get; set; }
        public double Qty { get; set; }
        public double? PurchaseQuantity { get; set; }
        public double? Wac { get; set; }
        public double? BuyingPrice { get; set; }
        public double? PreviousStockCost { get; set; }
    }
}
