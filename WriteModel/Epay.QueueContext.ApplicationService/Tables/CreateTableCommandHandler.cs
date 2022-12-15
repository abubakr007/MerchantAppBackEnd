using Epay.Constants;
using Epay.QueueContext.ApplicationService.Contracts.Tables;
using Epay.QueueContext.Domain.Tables;
using Epay.QueueContext.Domain.Tables.Services;
using Framework.Core.Application;
using Framework.Core.Persistence;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Epay.QueueContext.ApplicationService.Tables
{
    public class CreateTableCommandHandler : ICommandHandler<CreateTableCommand>
    {

        private readonly ITableRepository tableRepository;
        private readonly IEntityIdGenerator<Table> entityIdGenerator;
        private readonly IHttpContextAccessor httpContextAccessor;
        public CreateTableCommandHandler(ITableRepository tableRepositoryr, IEntityIdGenerator<Table> entityIdGenerator, IHttpContextAccessor httpContextAccessor)
        {
            this.entityIdGenerator = entityIdGenerator;
            this.tableRepository = tableRepositoryr;
            this.httpContextAccessor = httpContextAccessor;
        }
        public void Execute(CreateTableCommand command)
        {
            var userId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.Cashier)?.Value ?? "0");
            var merchantId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.MerchantId)?.Value ?? "0");
            var table = new Table(
                entityIdGenerator,
                command.TableNumber,
                command.TableName,
                command.TableCapacity,
                merchantId,
                userId);
            tableRepository.Create(table);
        }
    }
}
