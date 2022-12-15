using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class Provider
    {
        public int Id { get; set; }
        public string ProviderNameEn { get; set; } = null!;
        public string ProviderNameAr { get; set; } = null!;
        public string? PosPrintProviderName { get; set; }
        public byte[]? Poslogo { get; set; }
        public bool IsAllowedReprint { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool Status { get; set; }
        public long? LogoId { get; set; }
        public int ProviderCategoryId { get; set; }
        public bool? IsTotalApiallowed { get; set; }
        public string? ProviderNameTürki { get; set; }
    }
}
