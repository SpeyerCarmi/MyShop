using Entities;

namespace Service
{
    public interface IUserService
    {
       public Task<User> getUsers(string userName, string password);
        Task<User> insertUser(User user);
        void updateUser(int id, User user);

    }
}