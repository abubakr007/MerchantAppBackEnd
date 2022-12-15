using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.UserContext.ApplicationService.Contracts
{
    public class UserLoginThroughUserNameCommand : Command
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
