using Epay.Constants;
using Epay.ReadModel.Context;
using Epay.ReadModel.Queries.Contracts;
using Epay.ReadModel.Queries.Contracts.Dto;
using EPay.Data.Models;
using Framework.Core.Mapper;
using Framework.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Epay.ReadModel.Queries
{
    [Authorize]
    [ApiController]
    [Route("api/table/[action]")]
    public class TableQueryFacade : FacadeQueryBase, ITableQueryFacade
    {
        private readonly IMapper mapper;
        private readonly EpayContext db;
        public TableQueryFacade(IMapper mapper, EpayContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }
        [HttpGet]
        public IList<TableDto> GetAllTable()
        {
            var merchantId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.MerchantId)?.Value ?? "0");
            return mapper.Map<TableDto, Table>(db.Tables.Where(x => x.MerchantId == merchantId).ToList());
        }
        [HttpGet]
        public QueueStatusDto GetTableLastStatus(long tableId)
        {
            var status = db.QueueMasters.Include(x => x.QueueRestaurant).Where(x => x.QueueRestaurant.TableId == tableId).OrderByDescending(x => x.CreatedOn).FirstOrDefault()?.QueueStatus;
            return mapper.Map<QueueStatusDto, QueueStatus>(status);
        }

        [HttpGet]
        public IList<QueueMasterDto> GetAllOngoingQueuesForTable(long tableId)
        {
            var openQueues = db.QueueMasters
                .Include(x => x.QueueRestaurant)
                .Include(x => x.QueueStatus)
                .Include(x => x.QueueDetails.Where(x => !x.IsDeleted))
                .Where(x =>
                        x.QueueRestaurant.TableId == tableId &&
                        x.QueueStatus.Name != "Completed" &&
                        x.QueueStatus.Name != "Canceled" &&
                        !x.IsDeleted).ToList();
            return mapper.Map<QueueMasterDto, QueueMaster>(openQueues);
        }

    }
}
