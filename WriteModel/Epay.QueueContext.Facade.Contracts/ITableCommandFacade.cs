using Epay.QueueContext.ApplicationService.Contracts.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.QueueContext.Facade.Contracts
{
    public interface ITableCommandFacade
    {
        void AddTable(CreateTableCommand command);
        void DeleteTable(DeleteTableCommand command);
        void EditTable(UpdateTableCommand command);
    }
}
