using Epay.ReadModel.Context;
using Epay.ReadModel.Queries.Contracts.Dto;
using EPay.Data.Models;
using Framework.Core.Mapper;
using Framework.Core.Persistence;
using Framework.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Epay.ReadModel.Queries
{
    [ApiController]
    [Authorize]
    [Route("api/Dashboard/[action]")]
    public class DashboardQueryFacade: FacadeQueryBase, IFacadeQueryBase
    {
        private readonly EpayContext db;
        private readonly IMapper mapper;

        public DashboardQueryFacade(EpayContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public DashboardDto GetIncome(DateTime fromDate, DateTime toDate, string? merchantId)
        {
            var  trxWebReports = db.TrxWebReports.Where(x=> string.IsNullOrEmpty(merchantId) || x.MerchantId==merchantId );
            var today = DateTime.Now.Date;
            var TodayIncome = trxWebReports.Where(x => x.Date>= today).Sum(x => x.Trxvalue + x.TaxAmount);

            DayOfWeek currentDay = DateTime.Now.DayOfWeek;
            int daysTillCurrentDay = currentDay - DayOfWeek.Sunday;
            DateTime currentWeekStartDate = DateTime.Now.AddDays(-daysTillCurrentDay);
            var CurrentWeekIncome = trxWebReports.Where(x => x.Date.Value.Date>= currentWeekStartDate.Date&& x.Date.Value.Date <=today.Date).Sum(x => x.Trxvalue.Value + x.TaxAmount.Value);


            var CurrentMonth = today.Date.ToString("MMMM", new CultureInfo("en-US") );
            var CurrentMonthIncome = trxWebReports.Where(x => x.Date.Value.Date.Year == today.Date.Date.Year && x.Date.Value.Date.Month == today.Date.Date.Month).Sum(x => x.Trxvalue.Value + x.TaxAmount.Value);
            var trxWebReportsBetweenDate = trxWebReports.Where(x => x.Date.Value.Date >= fromDate && x.Date.Value.Date <= toDate);
            var queueLists = db.QueueLists.Where(x => x.CreatedOn >= fromDate && x.CreatedOn <= toDate);
            var completedQueue = queueLists.Count(x => (string.IsNullOrEmpty(merchantId) || x.MerchantId == merchantId) &&   x.QueueStatus == "Completed" );
            var pendingQueue = queueLists.Count(x =>( string.IsNullOrEmpty(merchantId) || x.MerchantId == merchantId)&& x.QueueStatus == "opened");
            var newCostomer = trxWebReportsBetweenDate.OrderByDescending(x => x.CustomerCreatedDate).FirstOrDefault()?.CustomerId ?? 0;

            List<YearIncomeDto> YearlyIncomes = GetYearlyIncome(trxWebReports);
            var endDate = today;
            List<MonthIncomeDto> last12MonthIncomes = Getlast12MonthIncome(trxWebReports, today);
            List<DayIncomeDto> last7DayIncomes = Getlast7DayIncome(trxWebReports, today);
            List<ProductIncomeDto> ProductList = GetProductIncomeBydaye(trxWebReports, fromDate, toDate);

            return new DashboardDto
            {
                TodayDate = today,
                TodayIncome = TodayIncome??0,
                //CurrentWeek = currentIncome.CurrentWeek,
               CurrentWeekIncome = CurrentWeekIncome,
                CurrentMonth = CurrentMonth,
                CurrentMonthIncome = CurrentMonthIncome,
                NewCustomerId = newCostomer,
                PendingQueue = pendingQueue,
                CompletedQueue = completedQueue,
                productIncomes = ProductList,
                YearlyIncomes = YearlyIncomes,
                last12MonthsIncomes = last12MonthIncomes,
                last7DaysIncomes = last7DayIncomes
            };  
        }

        private List<ProductIncomeDto> GetProductIncomeBydaye(IQueryable<TrxWebReport> trxWebReports, DateTime fromDate, DateTime toDate)
        {
            var trxWebReportsBetweenDate=trxWebReports.Where(x => x.Date.Value.Date >= fromDate && x.Date.Value.Date <= toDate);
            return trxWebReportsBetweenDate.GroupBy(x => new { x.ProductId, x.Product }).Select(x => new ProductIncomeDto
            {
                ProductId = x.Key.ProductId,
                Product = x.Key.Product,
                Income = x.Sum(x => x.Trxvalue.Value + x.TaxAmount.Value)
            }
             ).OrderByDescending(x => x.Income).ToList();
        }

        private static List<YearIncomeDto> GetYearlyIncome(IQueryable<TrxWebReport> trxWebReports)
        {
            List<YearIncomeDto> YearlyIncomes = new List<YearIncomeDto>();

            YearlyIncomes = trxWebReports
                    .GroupBy(x => x.Date.Value.Year)
                    .Select(x => new YearIncomeDto
                    {
                        Year = x.Key,
                        Income = x.Sum(x => x.Trxvalue.Value + x.TaxAmount.Value)
                    }).ToList();
            return YearlyIncomes;
        }
        private List<MonthIncomeDto> Getlast12MonthIncome(IQueryable<TrxWebReport> trxWebReports, DateTime today)
        {
            var trxWebReportLast12Month = trxWebReports.Where(x => x.Date.Value.Date >= today.AddMonths(-12) && x.Date.Value.Date <= today);
            List<MonthIncomeDto> last12MonthIncomeList = new List<MonthIncomeDto>();

            for (int i = 0; i <= 11; i++)
            {
                var x = trxWebReportLast12Month
                    .Where(x => x.Date.Value.Month == today.AddMonths(-i).Date.Month)
                    .GroupBy(x => x.Date.Value.Month)
                    .Select(x => new MonthIncomeDto
                    {
                        //Year = today.AddMonths(-i).Date.Year,
                        Month = today.AddMonths(-i).Date.Month,
                        //MonthName = today.AddMonths(-i).Date.ToString("MMMM", new CultureInfo("en-US")),
                        Income = x.Sum(x => x.Trxvalue.Value + x.TaxAmount.Value)
                    }).FirstOrDefault();
                if (x != null)
                    last12MonthIncomeList.Add(x);
            }
            var startDateForLast12Month = today.AddMonths(-11).Date;


            var MonthList = Enumerable.Range(0, 13).Select(a => startDateForLast12Month.AddMonths(a))
                         .TakeWhile(a => a <= today)
                         .Select(a => new MonthDto { Year= a.Date.Year, Month = a.Date.Month, MonthName = String.Concat(a.ToString("MMMM", new CultureInfo("en-US") )) }).ToList();

            return MonthList.GroupJoin(last12MonthIncomeList,
                MonthList => MonthList.Month,
                last12MonthIncomeList => last12MonthIncomeList.Month,
                    (x, y) => new { MonthList = x, last12MonthIncomeList = y })
                .SelectMany(
                        x => x.last12MonthIncomeList.DefaultIfEmpty(),
                         (x, y) => new { MonthList = x.MonthList, last12MonthIncomeList = y })
                .Select(s => new MonthIncomeDto
                {
                    Year=s.MonthList.Year,
                    Month = s.MonthList.Month,
                    MonthName = s.MonthList.MonthName,
                    Income = (s.last12MonthIncomeList != null) ? s.last12MonthIncomeList.Income : 0,
                }).ToList();
        }

        private List<DayIncomeDto> Getlast7DayIncome(IQueryable<TrxWebReport> trxWebReports, DateTime today)
        {
            var trxWebReportLast7Day = trxWebReports.Where(x => x.Date.Value.Date >= today.AddDays(-6) && x.Date.Value.Date <= today);
            List<DayIncomeDto> last7DaysIncomeList = new List<DayIncomeDto>();

            for (int i = 0; i <= 6; i++)
            {
                var x = trxWebReportLast7Day
                     .Where(x => x.Date.Value.Date == today.AddDays(-i).Date.Date)
                     .GroupBy(x => x.Date.Value.Date)
                     .Select(x => new DayIncomeDto
                     {
                         Date = today.AddMonths(-i).Date.Date,
                         DayName = today.AddDays(-i).Date.ToString("dddd", new CultureInfo("en-US")),
                         Income = x.Sum(x => x.Trxvalue.Value + x.TaxAmount.Value)
                     }).FirstOrDefault();
                if (x != null)
                    last7DaysIncomeList.Add(x);
            }

            var startDateForLast7Day = today.AddDays(-6).Date;
            var dayList = Enumerable.Range(0, 13).Select(a => startDateForLast7Day.AddDays(a))
                         .TakeWhile(a => a <= today)
                         .Select(a => new DayDto { Date = a.Date.Date, DayName = String.Concat(a.ToString("dddd", new CultureInfo("en-US")) ) }).ToList();

            return dayList.GroupJoin(last7DaysIncomeList,
                dayList => dayList.Date,
                last7DaysIncomeList => last7DaysIncomeList.Date,
                    (x, y) => new { dayList = x, last7DaysIncomeList = y })
                .SelectMany(
                        x => x.last7DaysIncomeList.DefaultIfEmpty(),
                         (x, y) => new { dayList = x.dayList, last7DaysIncomeList = y })
                .Select(s => new DayIncomeDto

                {
                    Date = s.dayList.Date.Date,
                    DayName = s.dayList.DayName,
                    Income = (s.last7DaysIncomeList != null) ? s.last7DaysIncomeList.Income : 0,
                }).ToList();
        }   
    }
}
