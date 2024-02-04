namespace Web_API_for_scheduling.Models.repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetList();
    }
}
