using API_for_mobile_app.model.entities;

namespace API_for_mobile_app.model.repositories.user_repository
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetListAsync();
        Users? GetAsync(Guid id);
        bool DeleteAsync(Guid id);
        bool PostData(Users entity);
        bool? PutData(Guid id, Users entity);
        bool EntityExists(Guid id);
    }
}
