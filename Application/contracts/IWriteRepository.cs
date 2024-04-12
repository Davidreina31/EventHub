namespace Application.contracts
{
    public interface IWriteRepository<T>
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(Guid id);
    }
}
