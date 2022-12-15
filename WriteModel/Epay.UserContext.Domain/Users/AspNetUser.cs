using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.UserContext.Domain.Users
{
    public class AspNetUser
    {
        public string Id { get; set; } = null!;
        public string? Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? Password { get; set; }
        public string? SecurityStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; } = null!;
        public long? MerchantId { get; set; }
        public bool? Status { get; set; }
        public string? UserLevel { get; set; }
       


    }
}
