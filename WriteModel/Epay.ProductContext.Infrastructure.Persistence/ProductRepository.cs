using Epay.ProductContext.Domain.Products;
using Epay.ProductContext.Domain.Products.Services;
using EPay.Data.Models;
using Framework.Core.Mapper;
using Framework.Core.Persistence;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Epay.ProductContext.Infrastructure.Persistence
{
    public class ProductRepository : DbFirstRepositoryBase, IProductRepository
    {
        public ProductRepository(IMapper mapper, IDbContext dbContext) : base(mapper, dbContext)
        {
        }

      

        public Domain.Products.Product GetProductById(int productId)
        {
            var product = GetDatabaseProduct(productId);
            return Mapper.Map<Domain.Products.Product, EPay.Data.Models.Product>(product);
        }

        public void UpdateProduct(Domain.Products.Product product)
        {
            var dataBaseproduct = Mapper.Map<EPay.Data.Models.Product, Domain.Products.Product>(product);
            DbContext.Update(dataBaseproduct);
        }

        public Domain.Products.PriceGroupDetail GetPriceGroupDetail(int priceGroupId, int productId)
        {
            var PriceGroupDetail = GetDatabasePriceGroupDetail(priceGroupId,productId);
            return Mapper.Map<Domain.Products.PriceGroupDetail, EPay.Data.Models.PriceGroupDetail>(PriceGroupDetail);
        }
        public void UpdatePriceGroupDetail(Domain.Products.PriceGroupDetail priceGroupDetail)
        {
            var dataBasePriceGroupDetail = Mapper.Map<EPay.Data.Models.PriceGroupDetail, Domain.Products.PriceGroupDetail>(priceGroupDetail);

            DbContext.Update(dataBasePriceGroupDetail);
        }

        private EPay.Data.Models.Product GetDatabaseProduct(int productId)
        {
            return DbContext.Set<EPay.Data.Models.Product>()
                .AsNoTracking()
                //.Include(x => x.logo)
                .Single(x => x.Id == productId);
        }
        private EPay.Data.Models.PriceGroupDetail GetDatabasePriceGroupDetail(int priceGroupId, int productId)
        {
            return DbContext.Set<EPay.Data.Models.PriceGroupDetail>()
                .AsNoTracking()
                .Single(x => x.ProductId == productId && x.PriceGroupMasterId==priceGroupId);
        }



    }
}