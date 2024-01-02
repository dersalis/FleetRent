namespace FleetRent.Core.Repositories
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}