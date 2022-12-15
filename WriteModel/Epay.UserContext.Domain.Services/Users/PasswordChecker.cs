using Epay.UserContext.Domain.Users;
using Epay.UserContext.Domain.Users.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.UserContext.Domain.Services.Users
{
    internal class PasswordChecker : IPasswordChecker
    {
        public bool IsPasswordCorrect(AspNetUser user, string password, string hashedPassword)
        {
            var ph = new PasswordHasher<AspNetUser>();
            var isOlderHashValid = ph.VerifyHashedPassword(user, hashedPassword, password);

            return (isOlderHashValid == PasswordVerificationResult.Success || isOlderHashValid == PasswordVerificationResult.SuccessRehashNeeded);
        }
    }
}
