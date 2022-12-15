using Epay.ReadModel.Queries.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.ReadModel.Queries.Contracts
{
    public interface IWorkerQueryFacade
    {
        IList<WorkerSaleDto> GetSaleWorkerByDate(DateTime fromDate, DateTime toDate);
    }
}
