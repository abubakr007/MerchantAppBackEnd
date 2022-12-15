using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class Tax
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Rate { get; set; }
        public string? Comment { get; set; }
        public bool IsActive { get; set; }
        public bool Status { get; set; }
    }
}
