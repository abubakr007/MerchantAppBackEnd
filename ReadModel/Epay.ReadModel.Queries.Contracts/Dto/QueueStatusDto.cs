using System.Collections.Generic;

namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public partial class QueueStatusDto
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public int NextStatus { get; set; }

    }
}
