namespace API_for_mobile_app.model.mappers
{
    public interface IMapSpecialEntities<F, K>
    {
        F? ToDTO(K entity);
    }
}
