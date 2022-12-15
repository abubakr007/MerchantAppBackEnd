using Epay.ProductContext.ApplicationService.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.ProductContext.Facade.Contracts
{
    public interface IProductCommandFacade
    {
        void EditProduct(UpdateProductCommand command);
    }
}
