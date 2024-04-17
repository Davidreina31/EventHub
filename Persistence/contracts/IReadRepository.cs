namespace Persistence.contracts
{
    public interface IReadRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
    }
}
