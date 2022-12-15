namespace Epay.CashierContext.Repository.Cashier
{
    public interface ICashierRepository
    {
        Domain.Cashier GetById(int id);
        void Create(Domain.Cashier cashier);
        void Update(Domain.Cashier cashier);
    }
}