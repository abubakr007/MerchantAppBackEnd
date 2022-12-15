using Epay.Constants;
using Epay.ReadModel.Context;
using Epay.ReadModel.Queries.Contracts;
using Epay.ReadModel.Queries.Contracts.Dto;
using EPay.Data.Models;
using Framework.Core.Mapper;
using Framework.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epay.ReadModel.Queries
{
    [ApiController]
    [Authorize]
    [Route("api/item/[action]")]
    public class ItemQueryFacade : FacadeQueryBase, IItemQueryFacade
    {
        public readonly int merchantId;
        public readonly int merchantNumber;
        public readonly int cashierId;
        private readonly IMapper mapper;
        private readonly EpayContext db;

        public ItemQueryFacade(IHttpContextAccessor httpContextAccessor, IMapper mapper, EpayContext db)
        {
            merchantId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.MerchantId)?.Value ?? "0");
            merchantNumber = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.MerchantCode)?.Value ?? "0");
            cashierId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.Cashier)?.Value ?? "0");
            this.mapper = mapper;
            this.db = db;
        }
        [HttpGet]
        public IList<CategoryDto> GetItemsForRelatedMerchant()
        {
            var itmListId = db.Merchants.Single(x => x.Recid == merchantId).ItemListId;

            var items = db.Items.AsNoTracking()
                .Include(x => x.ItemLoyalty)
                .Include(x => x.ItemPrice)
                .Where(x => x.ItemListId == itmListId && !x.IsDeleted).ToList();

            var subCategoryIds = items.Select(x => x.SubCategoryId).Distinct().ToList();

            var subCategories = db.SubCategories.Where(x => subCategoryIds.Contains(x.Id)).ToList();

            var categoryIds = subCategories.Select(x => x.CategoryId).Distinct().ToList();

            var categories = db.Categories.Where(x => categoryIds.Contains(x.Id)).ToList();

            var lst = new List<CategoryDto>();

            foreach (var category in categories)
            {
                lst.Add(new CategoryDto
                {
                    Id = category.Id,
                    ImageId = category.ImageId,
                    Name = new NameDto { En = category.NameEn, Fr = category.NameFr, Tr = category.NameTr, Ur = category.NameUr },
                    Sort = category.Sort,
                    SubCategories = subCategories.Where(x => x.CategoryId == category.Id).Select(subCategory => new SubCategoryDto
                    {
                        Id = subCategory.Id,
                        ImageId= subCategory.ImageId,
                        Name= new NameDto { En = subCategory.NameEn, Fr = subCategory.NameFr, Tr= subCategory.NameTr, Ur = subCategory.NameUr },
                        Sort = subCategory.Sort,
                        Items = items.Select(item => new ItemDto {
                            Id = item.Id,
                            Name = new NameDto { En = item.NameEn,Fr= item.NameFr, Tr = item.NameTr, Ur = item.NameUr },
                            Barcode = item.Barcode,
                            ImageId = item.ImageId,
                            IsActive = item.IsActive,
                            IsFastPrint = item.IsFastPrint,
                            ItemLoyalty = mapper.Map<ItemLoyaltyDto, ItemLoyalty>(item.ItemLoyalty),
                            ItemPrice = mapper.Map<ItemPriceDto, ItemPrice>(item.ItemPrice),
                            HasParam1 = item.HasParam1,
                            Description = item.Description,
                            IsSupervisorPassword = item.IsSupervisorPassword,   
                            Sort = item.Sort,
                        }).ToList()


                    }).ToList()
                });
            }
            return lst;

        }
    }
}
