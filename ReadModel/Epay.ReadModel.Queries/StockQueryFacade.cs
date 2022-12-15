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
using System.Linq;

namespace Epay.ReadModel.Queries
{
    [Authorize]
    [ApiController]
    [Route("api/stock/[action]")]
    public class StockQueryFacade : FacadeQueryBase, IStockQueryFacade
    {
        private readonly IMapper mapper;
        private readonly EpayContext db;
        public StockQueryFacade(IMapper mapper, EpayContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        [HttpPost]
        public QueryResult<GetStockDto> GetStocks([FromBody] QueryFilter filters)
        {
            var query = from product in db.Products
                        join providerCat in db.ProviderCategories on product.ProviderId equals providerCat.Id
                        join priceGroupDetails in db.PriceGroupDetails on product.Id equals priceGroupDetails.ProductId
                        join logo in db.Logos on product.LogoId equals logo.Id
                        join batch in db.Batches on product.Id equals batch.ProductId
                        select new GetStockDto { Id = product.Id, Name = product.ProductNameEng, Category = providerCat.Name, UnitPrice = priceGroupDetails.FaceValue, Quantity = batch.Qty, Image = logo.PathLocation };
        
            return QueryResult<GetStockDto>.GetQueryResult(mapper, query, filters);
        }

    }
}
