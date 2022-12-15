using Epay.CashierContext.Services.Commands;
using Framework.Core.Application;
using Framework.Core.Domain;
using Framework.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Epay.CashierContext.Facade
{
    public interface ICashierCommandFacade
    {
        void AddCashier(CreateCashierCommand command);

        void EditCashier(UpdateCashierCommand command);
    }
}
