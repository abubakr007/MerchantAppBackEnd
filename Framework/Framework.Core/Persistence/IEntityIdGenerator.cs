namespace Framework.Core.Persistence
{
    public interface IEntityIdGenerator<TEntity> where TEntity : class
    {
        long GetNewId();
    }
}