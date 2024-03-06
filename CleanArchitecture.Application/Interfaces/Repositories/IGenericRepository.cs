namespace CleanArchitecture.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<List<T>> GetAllAsList();
        void Delete(T entity);
        void Update(T entity);
        Task Create(T entity);
        Task CommitAsync();
    }
}
