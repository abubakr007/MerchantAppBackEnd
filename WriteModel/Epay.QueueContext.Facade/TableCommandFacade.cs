using Epay.QueueContext.ApplicationService.Contracts.Tables;
using Epay.QueueContext.Facade.Contracts;
using Framework.Core.Application;
using Framework.Core.Domain;
using Framework.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.QueueContext.Facade
{
    [Route("/api/Table/[action]")]
    [ApiController]
    [Authorize]
    public class TableCommandFacade : FacadeCommandBase, ITableCommandFacade
    {
        public TableCommandFacade(ICommandBus commandBus, IEventBus eventBus) : base(commandBus, eventBus)
        {
        }
        [HttpPost]
        public void AddTable(CreateTableCommand command)
        {
            CommandBus.Dispatch(command);
        }
        [HttpPost]
        public void DeleteTable(DeleteTableCommand command)
        {
            CommandBus.Dispatch(command);
        }
        [HttpPost]
        public void EditTable(UpdateTableCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
