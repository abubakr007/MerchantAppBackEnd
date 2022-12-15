using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class CategorizedItemsDto
    {
        public int Count => Categories.Count;
        public ICollection<CategoryDto> Categories { get; set; }
    }
}
