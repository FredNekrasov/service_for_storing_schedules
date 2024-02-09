using API_for_mobile_app.model.entities;
using Microsoft.EntityFrameworkCore;

namespace API_for_mobile_app.model.repositories.user_repository.implementation
{
    public class UserRepository(TimetableDbContext context) : IUserRepository
    {
        private readonly TimetableDbContext _context = context;
        public bool DeleteAsync(int id)
        {
            var users = _context.Users.Find(id);
            if (users == null) return false;

            _context.Users.Remove(users);
            _context.SaveChanges();
            return true;
        }
        public bool EntityExists(int id) => _context.Users.Any(e => e.UserID == id);
        public Users? GetAsync(int id) => _context.Users.Find(id);
        public IEnumerable<Users> GetListAsync() => _context.Users.ToList();
        public bool PostData(Users entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return true;
        }
        public bool? PutData(int id, Users entity)
        {
            if (id != entity.UserID) return false;
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id)) return null; else return false;
            }
            return true;
        }
    }
}
