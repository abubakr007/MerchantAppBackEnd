using System.Collections.Generic;

namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public NameDto Name { get; set; }
        public long? ImageId { get; set; }
        public int Sort { get; set; }
        public int Count => SubCategories.Count;

        public virtual ICollection<SubCategoryDto> SubCategories { get; set; }
    }
}
