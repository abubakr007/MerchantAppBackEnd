using Epay.UserContext.ApplicationService.Contracts;
using Epay.UserContext.Domain.Contracts.Events;
using Epay.UserContext.Domain.Users;
using Epay.UserContext.Domain.Users.Services;
using Framework.Core.Application;
using Framework.Core.Domain;

namespace Epay.UserContext.ApplicationService
{
    public class UserLoginCommandHandler : ICommandHandler<UserLoginCommand>
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenGenerator tokenGenerator;
        private readonly IEventBus eventBus;

        public UserLoginCommandHandler(IUserRepository userRepository, ITokenGenerator tokenGenerator, IEventBus eventBus)
        {
            this.userRepository = userRepository;
            this.tokenGenerator = tokenGenerator;
            this.eventBus = eventBus;
        }
        public void Execute(UserLoginCommand command)
        {
            User user = userRepository.GetUser(command.PosSerialNumber, command.TerminalId, command.Password);

            var token = new TokenGeneratedEvent();
            if (user != null)
            {
                token.AccessToken = tokenGenerator.AccessTokenGenerator(user.CashierId.ToString(), user.MerchantNumber, user.BusinessTypeId, user.MerchantId);
                eventBus.Publish(token);
            };
        }
    }
}
