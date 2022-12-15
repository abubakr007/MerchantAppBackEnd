using Epay.QueueContext.ApplicationService.Contracts.Tables;
using Epay.QueueContext.Domain.Tables.Services;
using Framework.Core.Application;

namespace Epay.QueueContext.ApplicationService.Tables
{
    public class UpdateTableCommandHandler : ICommandHandler<UpdateTableCommand>
    {
        private readonly ITableRepository tableRepository;
        public UpdateTableCommandHandler(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        }
        public void Execute(UpdateTableCommand command)
        {
            var table = tableRepository.GetTableById(command.Id);
            table.SetName(command.TableName);
            table.SetNumber(command.TableNumber);
            table.SetCapacity(command.TableCapacity);
            tableRepository.UpdateTable(table);
        }
    }
}
