using BLL.Models;
using DAL.Data.Repository;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class AuthRepository : RepositoryBase<User>, IAuthRepository
    {
        private readonly RepositoryContext _context;
        public AuthRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
            _context = repositoryContext;
        }
        
         public async Task<User> Login(string username, string password)
         {
             var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

             if (user == null)
                 return null;

             if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordKey))
                 return null;

             return user;
         }

         private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordKey)
         {
             using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordKey))
             {
                 var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                 for (int i = 0; i < computedHash.Length; i++)
                 {
                     if (computedHash[i] != passwordHash[i]) return false;
                 }
             }
             return true;
         }

         public async Task<User> Register(User user, string password)
         {
             byte[] passwordHash, passwordKey;
             CreatePasswordHash(password, out passwordHash, out passwordKey);

             user.PasswordHash = passwordHash;
             user.PasswordKey = passwordKey;

             await _context.Users.AddAsync(user);
             await _context.SaveChangesAsync();

             return user;
         }

         private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordKey)
         {
             using (var hmac = new System.Security.Cryptography.HMACSHA512())
             {
                 passwordKey = hmac.Key;
                 passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
             }
         }

         public async Task<bool> UserExists(string username)
         {
             if (await _context.Users.AnyAsync(x => x.Username == username))
                 return true;

             return false;
         }
    }
}
