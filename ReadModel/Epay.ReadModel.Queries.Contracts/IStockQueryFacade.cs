using Epay.ReadModel.Queries.Contracts.Dto;
using Framework.Filtering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.ReadModel.Queries.Contracts
{
    public interface IStockQueryFacade
    {
        QueryResult<GetStockDto> GetStocks(QueryFilter filter);
    }
}
