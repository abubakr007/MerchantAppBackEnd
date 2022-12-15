using Epay.ReadModel.Queries.Contracts.Dto;
using System.Collections.Generic;

namespace Epay.ReadModel.Queries.Contracts
{
    public interface IItemQueryFacade
    {
        IList<CategoryDto> GetItemsForRelatedMerchant();
    }
}
