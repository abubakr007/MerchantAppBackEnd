using Epay.ProductContext.ApplicationService.Contracts.Products;
using Epay.ProductContext.Facade.Contracts;
using Framework.Core.Application;
using Framework.Core.Domain;
using Framework.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Epay.ProductContext.Facade
{

    [Route("/api/Product/[action]")]
    [ApiController]
     [Authorize]
    public class ProductCommandFacade : FacadeCommandBase, IProductCommandFacade
    {
        public ProductCommandFacade(ICommandBus commandBus, IEventBus eventBus) : base(commandBus, eventBus)
        {
        }

        [HttpPost]
        public void EditProduct(UpdateProductCommand command)
        {
            CommandBus.Dispatch(command);
        }

    }
}
