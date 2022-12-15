namespace Epay.QueueContext.Domain.Tables.Services
{
    public interface ITableRepository
    {
        void Create(Table table);
        Table GetTableById(int tableId);
        void UpdateTable(Table table);
        void Remove(int tableId);
    }
}
