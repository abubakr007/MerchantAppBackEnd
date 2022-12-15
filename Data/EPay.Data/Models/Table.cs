using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class Table
    {
        public Table()
        {
            QueueRestaurants = new HashSet<QueueRestaurant>();
        }

        public int Id { get; set; }
        public int TableNumber { get; set; }
        public string? TableName { get; set; }
        public int TableCapacity { get; set; }
        public int MerchantId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Merchant Merchant { get; set; } = null!;
        public virtual ICollection<QueueRestaurant> QueueRestaurants { get; set; }
    }
}
