using Epay.QueueContext.Domain.Tables.Services;
using Framework.Core.Persistence;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.QueueContext.Domain.Tables
{
    public class Table : EntityBase<Table>
    {
        public Table(IEntityIdGenerator<Table> idGenerator, int tableNumber, string tableName, int tableCapacity, int merchantId, int createdBy) : base(idGenerator)
        {
            ModifiedOn = DateTime.Now;
            MerchantId = merchantId;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
            SetName(tableName);
            SetNumber(tableNumber);
            SetCapacity(tableCapacity);
            IsDeleted = false;
            SetId();

        }

        public void SetNumber(int number)
        {
            TableNumber = number;
        }

        public void SetCapacity(int capacity)
        {
            TableCapacity = capacity;
        }

        public void SetName(string tableName)
        {
            TableName = tableName;
        }

        public int TableNumber { get; set; }
        public string? TableName { get; set; }
        public int TableCapacity { get; set; }
        public int MerchantId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public int CashierId { get; set; }
    }
}
