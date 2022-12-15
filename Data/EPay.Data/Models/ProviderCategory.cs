using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class ProviderCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsActive { get; set; }
        public bool? Status { get; set; }
    }
}
