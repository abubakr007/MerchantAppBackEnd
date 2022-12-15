using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class ProductDto
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int productId { get; set; }
        public string ProductName { get; set; }
        public double? Quantity { get; set; }
        public double Price { get; set; }
     
    }
}
