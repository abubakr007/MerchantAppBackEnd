using Epay.UserContext.ApplicationService.Contracts;
using Epay.UserContext.Domain.Contracts.Events;
using Epay.UserContext.Facade.Contracts;
using Framework.Core.Application;
using Framework.Core.Domain;
using Framework.Facade;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Epay.UserContext.Facade
{
    [Route("/api/Users/[action]")]
    [ApiController]
    public class UserCommandFacade : FacadeCommandBase, IUserCommandFacade
    {
        public UserCommandFacade(ICommandBus commandBus, IEventBus eventBus) : base(commandBus, eventBus)
        {
        }
        [HttpPost]
        public TokenGeneratedEvent LoginUser(UserLoginCommand command)
        {
            TokenGeneratedEvent tokenEvent = null;
            EventBus.Subscribe<TokenGeneratedEvent>(a => tokenEvent = a);
            CommandBus.Dispatch(command);
            return tokenEvent;
        }
        [HttpPost]
        public AspUserLoginedEvent LoginUserThroughUserName(UserLoginThroughUserNameCommand command)
        {
            AspUserLoginedEvent responseEvent = null;
            EventBus.Subscribe<AspUserLoginedEvent>(a => responseEvent = a);
            CommandBus.Dispatch(command);
            return responseEvent;
        }
    }
}
;