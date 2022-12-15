using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class TransactionDetailDto
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public double? Quantity { get; set; }
        public double? Price { get; set; }
        public double? Total { get; set; }

    }
}
