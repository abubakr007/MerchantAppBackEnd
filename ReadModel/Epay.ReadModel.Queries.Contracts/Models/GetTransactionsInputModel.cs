using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.ReadModel.Queries.Contracts.Models
{
    public  class GetTransactionsInputModel
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? CashierId { get; set; }
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }

    }
}