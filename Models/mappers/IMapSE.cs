
namespace Web_API_for_scheduling.Models.mappers
{
    public interface IMapSE<T, K>
    {
        T? ToEntity(K dto);
        Task<K?> ToDtoAsync(T entity);
    }
}
