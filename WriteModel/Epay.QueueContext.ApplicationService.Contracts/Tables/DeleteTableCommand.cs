using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.QueueContext.ApplicationService.Contracts.Tables
{
    public class DeleteTableCommand : Command
    {
        public int Id { get; set; }
    }
}
