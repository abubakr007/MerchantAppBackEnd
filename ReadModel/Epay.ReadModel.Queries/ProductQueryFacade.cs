using Epay.ReadModel.Context;
using Epay.ReadModel.Queries.Contracts.Dto;
using Epay.ReadModel.Queries.Contracts;
using EPay.Data.Models;
using Framework.Facade;
using Framework.Filtering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Mapper;

namespace Epay.ReadModel.Queries
{

    [ApiController]
    [Authorize]
    [Route("api/Product/[action]")]
    public class ProductQueryFacade:  FacadeQueryBase,IProductQueryFacade
    {
        private readonly EpayContext db;
        private readonly IMapper mapper;

        public ProductQueryFacade(EpayContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        [HttpGet]
       public IList<ProductDto> GetProducts(string? merchantId)
        {
            var priceGroupMasterIds = db.Merchants.Where(x => string.IsNullOrEmpty(merchantId) || x.MerchantId == merchantId).Select(x => x.PricingGroupId);

            var productIds = db.PriceGroupDetails.Where(x => priceGroupMasterIds.Contains(x.PriceGroupMasterId)).Select(x => x.ProductId);



            var productQuery =
                db.Products.Where(x => productIds.Contains(x.Id))
                .Join(db.PriceGroupDetails,
               product => product.Id,
               priceDetail => priceDetail.ProductId,
               (product, priceDetail) => new
               {

                   ProductId = product.Id,
                   ProductName = product.ProductNameEng,
                   SubCategoryId = product.ProviderId,
                   product.Quantity,
                   Price = priceDetail.BuyingPrice,

               })
                 .Join(db.Providers,
               product => product.SubCategoryId,
               subcategory => subcategory.Id,
               (product, subcategory) => new
               {

                   product.ProductId,
                   product.ProductName,
                   product.Quantity,
                   product.Price,
                   product.SubCategoryId,
                   SubCategoryName = subcategory.ProviderNameEn,
                   CategoryId = subcategory.ProviderCategoryId

               })
                    .Join(db.ProviderCategories,
               product => product.CategoryId,
               category => category.Id,
               (product, category) => new ProductDto
               {

                   productId = product.ProductId,
                   ProductName = product.ProductName,
                   Quantity = product.Quantity,
                   Price = product.Price,
                   SubCategoryId = product.SubCategoryId,
                   SubCategoryName = product.SubCategoryName,
                   CategoryId = product.CategoryId,
                   CategoryName = category.Name

               });


            return productQuery.ToList();
             

         


        }

     
    }
}
