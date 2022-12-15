using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.QueueContext.ApplicationService.Contracts.Tables
{
    public class CreateTableCommand : Command
    {
        public int TableNumber { get; set; }
        public string? TableName { get; set; }
        public int TableCapacity { get; set; }
       
    }
}
