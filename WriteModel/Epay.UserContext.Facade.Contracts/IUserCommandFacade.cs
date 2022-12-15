using Epay.UserContext.ApplicationService.Contracts;
using Epay.UserContext.Domain.Contracts.Events;
using System;

namespace Epay.UserContext.Facade.Contracts
{
    public interface IUserCommandFacade 
    {
        TokenGeneratedEvent LoginUser(UserLoginCommand command);
    }
}
