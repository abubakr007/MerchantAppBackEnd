using System.Collections.Generic;

namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class SubCategoryDto
    {
        public long Id { get; set; }
        public NameDto Name { get; set; }
        public long? ImageId { get; set; }
        public int Sort { get; set; }
        public int Count => Items.Count;
        public virtual ICollection<ItemDto> Items { get; set; }
    }
}
