using System;
using System.Collections.Generic;

namespace Epay.ReadModel.Queries.Contracts.Dto
{

    public class Report_CurrenIncomeDto
    {

        public DateTime TodayDate { get; set; }
        public decimal TodayIncome { get; set; }
        public int CurrentWeek { get; set; }
        public decimal CurrentWeekIncome { get; set; }
        public int CurrentMonth { get; set; }
        public decimal CurrentMonthIncome { get; set; }
    }


    public class MonthIncomeDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public double Income { get; set; }
     
  
    }
    public class YearIncomeDto
    {
        public int Year { get; set; }
      
        public double Income { get; set; }


    }
    public class MonthDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
    }
    public class DayDto
    {
        public DateTime Date { get; set; }
        public string DayName { get; set; }
    }
    public class DayIncomeDto
    {

        
        public DateTime Date { get; set; }
   
        public string DayName { get; set; }
        public double Income { get; set; }
    }


    public class Report_last12MonthsIncomeDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public double Income { get; set; }
    }
    public class Report_last7DaysIncomeDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string MonthName { get; set; }
        public string DayName { get; set; }
        public double Income { get; set; }
    }

    public class ProductIncomeDto
    {
        public int ProductId { get; set; }
        public string Product { get; set; }
        public double Income { get; set; }
    
    }
    public class DashboardDto
    {
        public DateTime TodayDate { get; set; }
        public double TodayIncome { get; set; }
        public int CurrentWeek { get; set; }
        public double CurrentWeekIncome { get; set; }
        public string CurrentMonth { get; set; }
        public double CurrentMonthIncome { get; set; }
        public long NewCustomerId { get; set; }
        public int PendingQueue { get; set; }
        public int CompletedQueue { get; set; }
        public List<ProductIncomeDto> productIncomes { get; set; }
        public Report_CurrenIncomeDto CurrenIncome { get; set; }
        public List<YearIncomeDto> YearlyIncomes { get; set; }
        public List<MonthIncomeDto> last12MonthsIncomes { get; set; }
        public List<DayIncomeDto> last7DaysIncomes { get; set; }
   
    }
}
