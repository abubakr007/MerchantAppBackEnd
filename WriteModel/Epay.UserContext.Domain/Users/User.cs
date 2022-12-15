using System;

namespace Epay.UserContext.Domain.Users
{
    public class User
    {
        public int CashierId { get; set; }
        public string Password { get; set; }
        public int MerchantId { get; set; }
        public string MerchantNumber { get; set; }
        public int BusinessTypeId { get; set; }
        public string TerminalId { get; set; }
        public string PosSerialNumber { get; set; }
        public bool IsLocked { get; set; }
    }
}
