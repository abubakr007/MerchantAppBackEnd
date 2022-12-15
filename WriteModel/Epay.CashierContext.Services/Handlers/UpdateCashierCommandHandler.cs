using Epay.CashierContext.Repository.Cashier;
using Epay.CashierContext.Services.Commands;
using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.CashierContext.Services.Handlers
{
    public class UpdateCashierCommandHandler : ICommandHandler<UpdateCashierCommand>
    {
        private readonly ICashierRepository repository;

        public UpdateCashierCommandHandler(ICashierRepository repository)
        {
            this.repository=repository;
        }

        public void Execute(UpdateCashierCommand command)
        {
            var cashier = repository.GetById(command.Id);
            if (!string.IsNullOrEmpty(command.Name))
                cashier.Name=command.Name;
            if (!string.IsNullOrEmpty(command.Password))
                cashier.Password= command.Password;
            if (!string.IsNullOrEmpty(command.Cashiertype))
                cashier.Cashiertype= command.Cashiertype;

            repository.Update(cashier);
        }
    }
}
