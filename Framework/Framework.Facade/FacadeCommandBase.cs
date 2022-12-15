using Framework.Core.Application;
using Framework.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Framework.Facade
{
    public abstract class FacadeCommandBase : Controller
    {
        protected FacadeCommandBase(ICommandBus commandBus, IEventBus eventBus)
        {
            CommandBus = commandBus;
            EventBus = eventBus;
        }

        protected ICommandBus CommandBus { get; private set; }
        protected IEventBus EventBus { get; private set; }
    }
}