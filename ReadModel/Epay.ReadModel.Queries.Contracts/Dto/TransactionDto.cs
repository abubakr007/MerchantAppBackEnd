using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class TransactionDto
    {
        public string RefNo { get; set; }
        public string UserName { get; set; }
        public long TransactionNo { get; set; }
        public string Voucher { get; set; }
        public DateTime? Date { get; set; }
        public string Payment { get; set; }
        public double? Total { get; set; }
        public List<TransactionDetailDto> Details { get; set; }
    }
}
