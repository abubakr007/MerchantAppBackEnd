using Epay.ReadModel.Context;
using Epay.ReadModel.Queries.Contracts;
using Epay.ReadModel.Queries.Contracts.Dto;
using EPay.Data.Models;
using Framework.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Epay.ReadModel.Queries
{
    [ApiController]
    [Authorize]
    [Route("api/Worker/[action]")]
    public class WorkerQueryFacade :FacadeQueryBase, IWorkerQueryFacade
    {
        private readonly EpayContext db;

        public WorkerQueryFacade(EpayContext db)
        {
            this.db = db;
        }
        [HttpPost]
        public IList<WorkerSaleDto> GetSaleWorkerByDate(DateTime fromDate, DateTime toDate)
        {
                     var query=db.TransactionMasters
                    .Where(x => x.TrxTime.Date >= fromDate && x.TrxTime.Date <= toDate)

                    .Join(db.TransactionDetails,
                          master => master.Id,
                          detail => detail.TransactionMasterId,
                          (master, detail) => new
                          {
                              detail.TransactionMasterId,
                              master.CashierId,
                              sale = detail.CustomerPaidAmount.Value + detail.TaxAmount.Value
                          })
                    .Join(db.Cashiers,
                          master => master.CashierId,
                          cashier => cashier.Id,
                          (master, cashier) => new
                          {
                              cashierId= master.CashierId.Value,
                              cashierName=cashier.Name,
                              master.sale
                          }).AsEnumerable();

           return query.GroupBy(x=> new { x.cashierId, x.cashierName })
                .Select(x=> new  WorkerSaleDto
                {
                 WorkerId=x.Key.cashierId,
                 WorkerName= x.Key.cashierName,
                 Sales= x.Sum(x=>x.sale)} ).
                 OrderByDescending(x=>x.Sales)
                 .ToList();

        }
    }
}
