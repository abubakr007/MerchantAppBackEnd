using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.UserContext.Domain.Users.Services
{
    public interface IPasswordChecker: IDomainService
    {
        bool IsPasswordCorrect(AspNetUser user, string password, string hashedPassword);
    }
}
