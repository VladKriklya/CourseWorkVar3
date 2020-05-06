using BLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly CupDataContext _context;
        public DatingRepository(CupDataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

      
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }   
    }
}
