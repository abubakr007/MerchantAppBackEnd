using Epay.Constants;
using Epay.ReadModel.Context;
using Epay.ReadModel.Queries.Contracts;
using Epay.ReadModel.Queries.Contracts.Dto;
using EPay.Data.Models;
using Framework.Core.Mapper;
using Framework.Facade;
using Framework.Filtering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Epay.ReadModel.Queries
{
    [Authorize]
    [ApiController]
    [Route("api/queue/[action]")]
    public class QueueQueryFacade : FacadeQueryBase, IQueueQueryFacade
    {
        private readonly IMapper mapper;
        private readonly EpayContext db;

        public QueueQueryFacade(IMapper mapper, EpayContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }
        [HttpGet]
        public IList<QueueMasterDto> GetAllQueues()
        {
            return mapper.Map<QueueMasterDto, QueueMaster>(db.QueueMasters.Where(x => !x.IsDeleted).Include(x => x.QueueDetails.Where(x => !x.IsDeleted)).ToList());
        }
        [HttpPost]
        public QueryResult<QueueMasterDto> GetQueues([FromBody] QueryFilter filters)
        {
            var result = new QueueMasterWitTotalPageDto();
            var queuesQuery = db.QueueMasters.Where(x => !x.IsDeleted).Include(x => x.QueueDetails.Where(x => !x.IsDeleted)).AsQueryable();
            return QueryResult<QueueMasterDto>.GetQueryResult(mapper, queuesQuery, filters);
        }
        [HttpGet]
        public QueueMasterDto GetQueueByNumber(int number)
        {
            var queue = db.QueueMasters.Where(x => !x.IsDeleted).Include(x => x.QueueDetails.Where(x => !x.IsDeleted)).Single(x => x.TokenNumber == number);
            return mapper.Map<QueueMasterDto, QueueMaster>(queue);
        }
        [HttpGet]
        public QueueMasterDto GetQueueById(long id)
        {
            var queue = db.QueueMasters.Where(x => !x.IsDeleted).Include(x => x.QueueDetails.Where(x => !x.IsDeleted)).Include(x => x.QueueStatus).Single(x => x.Id == id);
            var result = mapper.Map<QueueMasterDto, QueueMaster>(queue);


            var customer = db.Customers.Where(x => x.Id == result.CustomerId).Select(x => new { x.Id, Name = x.FirstName + ' ' + x.LastName, x.ContactNumber }).SingleOrDefault();
            result.CustomerName = customer?.Name;
            result.CustomerPhoneNumber = customer?.ContactNumber;

            var productIds = result.QueueDetails.Select(x => x.ProductId).ToList();

            var products = db.Products.Where(x => productIds.Contains(x.Id)).Select(x => new { x.Id, x.ProductNameEng, x.ProductNameAr, x.ProductNameTurki }).ToList();

            foreach (var detail in result.QueueDetails)
            {
                var pr = products.First(x => x.Id == detail.ProductId);
                detail.ProductNameEn = pr.ProductNameEng;
                detail.ProductNameAr = pr.ProductNameAr;
                detail.ProductNameTr = pr.ProductNameTurki;
            }

            return result;

        }


        [HttpGet]
        public IList<long> GetAllQueuesId()
        {
            return db.QueueMasters.Where(x => !x.IsDeleted).Select(x => x.Id).ToList();
        }
        [HttpGet]
        public IList<QueueStatusDto> GetAllQueueStatus()
        {
            var busineesTypeId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.BusinessTypeId)?.Value ?? "0");
            var statuses = db.QueueStatuses.Where(x => x.BusinessTypeId == busineesTypeId).ToList();
            return mapper.Map<QueueStatusDto, QueueStatus>(statuses);
        }
        [HttpPost]
        public QueryResult<QueueMasterDto> GetAllQueuesByStatusId(long statusId, [FromBody] QueryFilter filters)
        {
            var merchantId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.MerchantId)?.Value ?? "0");
            var query = db.QueueMasters
                .Include(x => x.QueueDetails.Where(x => !x.IsDeleted))
                .Include(x => x.QueueRestaurant)
                .Where(x => x.MerchantId == merchantId && x.QueueStatusId == statusId && !x.IsDeleted);
            return QueryResult<QueueMasterDto>.GetQueryResult(mapper, query, filters);
        }

        [HttpPost]
        public QueryResult<QueueMasterDto> GetAllOpenedQueues([FromBody] QueryFilter filters)
        {
            var merchantId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.MerchantId)?.Value ?? "0");
            var query = db.QueueMasters
                .Include(x => x.QueueDetails.Where(x => !x.IsDeleted))
                .Include(x => x.QueueRestaurant)
                .Include(x => x.QueueStatus)
                .Include(x => x.QueueLaundary)
                .Where(x => x.MerchantId == merchantId && x.QueueStatus.Name != "Complete" && x.QueueStatus.Name != "Cancel" && !x.IsDeleted);
            var result = QueryResult<QueueMasterDto>.GetQueryResult(mapper, query, filters);

            var customerIds = result.Value.Select(x => x.CustomerId).Distinct().ToList();

            var customers = db.Customers.Where(x => customerIds.Contains(x.Id)).Select(x => new { x.Id, Name = x.FirstName + ' ' + x.LastName, x.ContactNumber }).ToList();

            var productIds = result.Value.SelectMany(x => x.QueueDetails).Select(x => x.ProductId).ToList();

            var products = db.Products.Where(x => productIds.Contains(x.Id)).Select(x => new { x.Id, x.ProductNameEng, x.ProductNameAr, x.ProductNameTurki }).ToList();

            foreach (var item in result.Value)
            {
                item.CustomerName = customers.FirstOrDefault(x => x.Id == item.CustomerId)?.Name;
                item.CustomerPhoneNumber = customers.FirstOrDefault(x => x.Id == item.CustomerId)?.ContactNumber;
                foreach (var detail in item.QueueDetails)
                {
                    var pr = products.First(x => x.Id == detail.ProductId);
                    detail.ProductNameEn = pr.ProductNameEng;
                    detail.ProductNameAr = pr.ProductNameAr;
                    detail.ProductNameTr = pr.ProductNameTurki;
                }
            }

            return result;
        }
    }
}
