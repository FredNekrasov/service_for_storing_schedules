using Web_API_for_scheduling.Models.dto;
using Web_API_for_scheduling.Models.entities;

namespace Web_API_for_scheduling.Models.mappers.pair
{
    public interface IMapPair
    {
        Pair? ToPair(PairDto dto);
        Task<PairDto?> ToDtoAsync(Pair entity);
    }
}
