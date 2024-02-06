namespace Web_API_for_scheduling.Models.repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetListAsync();
        Task<T?> GetAsync(int id);
        Task<bool?> DeleteAsync(int id);
        Task<bool> PostData(T entity);
        Task<bool?> PutData(int id, T entity);
        bool EntityExists(int id);
    }
}
