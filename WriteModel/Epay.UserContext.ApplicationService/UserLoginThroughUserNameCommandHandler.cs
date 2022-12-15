using Epay.UserContext.ApplicationService.Contracts;
using Epay.UserContext.Domain.Contracts.Events;
using Epay.UserContext.Domain.Users.Services;
using Framework.Core.Application;
using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.UserContext.ApplicationService
{
    public class UserLoginThroughUserNameCommandHandler : ICommandHandler<UserLoginThroughUserNameCommand>
    {
        private readonly IUserRepository userRepository;

        private readonly ITokenGenerator tokenGenerator;
        private readonly IPasswordChecker passwordChecker;
        private readonly IEventBus eventBus;

        public UserLoginThroughUserNameCommandHandler(IUserRepository userRepository, ITokenGenerator tokenGenerator, IPasswordChecker passwordChecker, IEventBus eventBus
            )
        {
            this.userRepository = userRepository;
            this.tokenGenerator = tokenGenerator;
            this.passwordChecker = passwordChecker;
            this.eventBus = eventBus;
        }
        public void Execute(UserLoginThroughUserNameCommand command)
        {
            var user = userRepository.GetAspNetUserByUserName(command.UserName);
            var isPasswordCorrect = passwordChecker.IsPasswordCorrect(user, command.Password, user.PasswordHash);
            if (isPasswordCorrect)
            {
                var response = new AspUserLoginedEvent();
                response.UserName = command.UserName;
                response.MerchantId = user.MerchantId.ToString();
                response.AccessToken = tokenGenerator.AccessTokenGeneratorForAspUser(user.UserName, user.UserLevel, user.MerchantId.ToString());
                eventBus.Publish(response);
            };
        }
    }
}
