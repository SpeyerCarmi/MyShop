using Entities;

namespace Repository
{
    public interface IUserRepository
    {
       public Task <User> getUsers(string userName, string password);
       Task <User> insertUser(User user);
        Task updateUser(int id, User user);
    }
   
}