using API_for_mobile_app.model.entities;

namespace API_for_mobile_app.model.repositories.user_repository
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetListAsync();
        Users? GetAsync(int id);
        bool DeleteAsync(int id);
        bool PostData(Users entity);
        bool? PutData(int id, Users entity);
        bool EntityExists(int id);
    }
}
