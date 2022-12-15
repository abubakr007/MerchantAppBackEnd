using Epay.CashierContext.Repository.Cashier;
using Epay.CashierContext.Services.Commands;
using Epay.Constants;
using Framework.Core.Application;
using Microsoft.AspNetCore.Http;

namespace Epay.CashierContext.Services.Handlers
{
    public class AddCashierCommandHandler : ICommandHandler<CreateCashierCommand>
    {
        private readonly ICashierRepository repository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AddCashierCommandHandler(ICashierRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            this.repository = repository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public void Execute(CreateCashierCommand command)
        {
            var cashier = new Domain.Cashier()
            {
                Name = command.Name,
                Password = command.Password,
                Cashiertype = command.Cashiertype,
                CashierKind = "POS",
                MerchantId = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.MerchantId)?.Value ?? "0"

            };
            repository.Create(cashier);
        }
    }
}
