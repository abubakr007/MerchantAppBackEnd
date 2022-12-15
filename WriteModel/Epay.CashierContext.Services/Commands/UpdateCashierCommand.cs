using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.CashierContext.Services.Commands
{
    public class UpdateCashierCommand :Command
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public string? Cashiertype { get; set; } = null!;
    }
}
