using BLL.Models;
using System.Threading.Tasks;

namespace DAL.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
        void CreateUser(User user);
    }
}