using Epay.ReadModel.Context;
using Epay.ReadModel.Queries.Contracts;
using Epay.ReadModel.Queries.Contracts.Dto;
using Epay.ReadModel.Queries.Contracts.Models;
using Framework.Facade;
using Framework.Filtering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epay.ReadModel.Queries
{
    [Authorize]
    [ApiController]
    [Route("api/transaction/[action]")]
    public class TransactionQueryFacade : FacadeQueryBase, ITransactionQueryFacade
    {
        private readonly EpayContext db;
        public TransactionQueryFacade(EpayContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public List<TransactionDto> GetTransactions([FromBody] GetTransactionsInputModel model)
        {
            var query = db.GetTransactions
                .Where(w => (!model.DateFrom.HasValue || w.Date >= model.DateFrom) && (!model.DateTo.HasValue || w.Date <= model.DateTo) && (!model.CashierId.HasValue || w.CashierId == model.CashierId ) && (!model.ProductId.HasValue || w.ProductId == model.ProductId) && (!model.CategoryId.HasValue || w.CategoryId == model.CategoryId)).ToList()
                .GroupBy(g => new { g.ReferenceNo, g.CashierName, g.VoucherNo, g.TransactionNo, g.Date, g.PaymentMode, g.TotalAmount })
                .Select(g => new TransactionDto
                {
                    RefNo = g.Key.ReferenceNo,
                    UserName = g.Key.CashierName,
                    TransactionNo = g.Key.TransactionNo,
                    Voucher = g.Key.VoucherNo,
                    Payment = g.Key.PaymentMode,
                    Date = g.Key.Date,
                    Total = g.Key.TotalAmount,
                    Details = g.Select(s => new TransactionDetailDto { ProductName = s.ProductNameEng, Price = s.FaceValue, Category = s.CategoryName, SubCategory = s.SubCategoryName, Quantity = s.TotalQty, Total = s.TotalPrice }).ToList()
                }).ToList();
            return query;
        }
    }
}
