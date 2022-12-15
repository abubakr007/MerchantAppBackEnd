using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class Customer
    {
        public Customer()
        {
            QueueMasters = new HashSet<QueueMaster>();
            SmartCards = new HashSet<SmartCard>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public double? Balance { get; set; }
        public string? Address { get; set; }
        public string? ContactNumber { get; set; }
        public int? CreditPeriod { get; set; }
        public double? CreditLimit { get; set; }
        public long? PricinglevelId { get; set; }
        public string? Trn { get; set; }
        public bool IsActive { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public string MerchantId { get; set; } = null!;
        public string MerchantGroupId { get; set; } = null!;
        public string? CategoryType { get; set; }
        public string? CustomerType { get; set; }
        public string? Email { get; set; }
        public string? CarNumber { get; set; }
        public string? Vfcode { get; set; }
        public string? Password { get; set; }
        public string? Image { get; set; }
        public string? Pobox { get; set; }
        public string? Location { get; set; }
        public string? BalanceType { get; set; }
        public string? BirthDate { get; set; }
        public string? City { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public int Points { get; set; }
        public string? Gender { get; set; }
        public double? Savings { get; set; }
        public bool? IsCustomerRegistered { get; set; }
        public string? InviteCode { get; set; }
        public bool? IsCodeConsumed { get; set; }

        public virtual ICollection<QueueMaster> QueueMasters { get; set; }
        public virtual ICollection<SmartCard> SmartCards { get; set; }
    }
}
