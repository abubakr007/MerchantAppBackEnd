using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.CashierContext.Domain
{
    public class Cashier : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
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
    }
}
