using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.QueueContext.ApplicationService.Contracts.Tables
{
    public class UpdateTableCommand : Command
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public string TableName { get; set; }
        public int TableCapacity { get; set; }
    }
}
