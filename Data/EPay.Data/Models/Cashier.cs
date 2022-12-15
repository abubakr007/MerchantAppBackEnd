using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class Cashier
    {
        public Cashier()
        {
            QueueLists = new HashSet<QueueList>();
            QueueMasters = new HashSet<QueueMaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Status { get; set; }
        public string Password { get; set; } = null!;
        public string CashierKind { get; set; } = null!;
        public bool Forcetomodifypassword { get; set; }
        public string Cashiertype { get; set; } = null!;
        public string MerchantId { get; set; } = null!;
        public string? UserShiftId { get; set; }
        public double? Balance { get; set; }
        public string? City { get; set; }
        public string? DutyType { get; set; }
        public int? TotalDutyDays { get; set; }
        public double? BasicSalary { get; set; }
        public double? SafityLimit { get; set; }
        public string? Gender { get; set; }
        public int ShiftType { get; set; }
        public bool? Deduction { get; set; }
        public string? YallaWashPassword { get; set; }
        public string? CommissionPercentage { get; set; }

        public virtual ICollection<QueueList> QueueLists { get; set; }
        public virtual ICollection<QueueMaster> QueueMasters { get; set; }
    }
}
