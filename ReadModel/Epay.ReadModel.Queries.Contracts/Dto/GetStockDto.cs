using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class GetStockDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double? UnitPrice { get; set; }
        public double? Quantity { get; set; }
        public string Image { get; set; }
    }
}
