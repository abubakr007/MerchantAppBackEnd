using Epay.Constants;
using Epay.UserContext.Domain.Users.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Epay.UserContext.Domain.Services.Users
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration configuration;

        public TokenGenerator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string AccessTokenGenerator(string userName, string merchantNumber, int businessTypeId, int merchantId)
        {
            var mySecret = configuration["Jwt:Key"];
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim(ApplicationClaims.Cashier, userName),
                     new Claim(ApplicationClaims.MerchantId, merchantId.ToString()),
                     new Claim(ApplicationClaims.BusinessTypeId, businessTypeId.ToString()),
                     new Claim(ApplicationClaims.MerchantCode, merchantNumber),
                }),
                Audience = configuration["Jwt:Audience"],
                Issuer = configuration["Jwt:Issuer"],
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string AccessTokenGeneratorForAspUser(string userName, string userLevel, string merchantId)
        {
            var mySecret = configuration["Jwt:Key"];
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim(NewApplicationClaims.UserName, userName),
                     new Claim(NewApplicationClaims.MerchantId, merchantId.ToString()),
                     new Claim(NewApplicationClaims.UserLevel, userLevel),

                }),
                Audience = configuration["Jwt:Audience"],
                Issuer = configuration["Jwt:Issuer"],
                Expires = DateTime.UtcNow.AddDays(100),
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
