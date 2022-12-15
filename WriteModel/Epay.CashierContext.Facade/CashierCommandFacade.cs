using Epay.CashierContext.Services.Commands;
using Framework.Core.Application;
using Framework.Core.Domain;
using Framework.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Epay.CashierContext.Facade
{
    [Route("/api/Cashier/[action]")]
    [ApiController]
    [Authorize]
    public class CashierCommandFacade : FacadeCommandBase, ICashierCommandFacade
    {
        public CashierCommandFacade(ICommandBus commandBus, IEventBus eventBus) : base(commandBus, eventBus)
        {
           
        }

        [HttpPost]
        public void AddCashier(CreateCashierCommand command)
        {
            CommandBus.Dispatch(command);
        }

        [HttpPost]
        public void EditCashier(UpdateCashierCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
