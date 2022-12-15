using Epay.QueueContext.ApplicationService.Contracts.Tables;
using Epay.QueueContext.Domain.Tables.Services;
using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.QueueContext.ApplicationService.Tables
{
    public class DeleteTableCommandHandler : ICommandHandler<DeleteTableCommand>
    {
        private readonly ITableRepository tableRepository;

        public DeleteTableCommandHandler(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        }
        public void Execute(DeleteTableCommand command)
        {
            tableRepository.Remove(command.Id);
        }
       
    }
}
