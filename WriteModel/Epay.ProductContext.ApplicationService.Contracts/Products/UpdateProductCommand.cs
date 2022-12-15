using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.ProductContext.ApplicationService.Contracts.Products
{
    public class UpdateProductCommand :Command
    {

        public string MerchantId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Quantity { get; set; }
        public bool Active { get; set; }
        public double Price { get; set; }
        public long? LogoId { get; set; }

    }
}


   
   
