namespace Web_API_for_scheduling.Models.repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetListAsync();
        Task<T?> GetAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> PostData(T entity);
        Task<bool?> PutData(Guid id, T entity);
        bool EntityExists(Guid id);
    }
}
