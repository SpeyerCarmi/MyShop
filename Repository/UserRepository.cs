using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        readonly MyDatabaseContext _dbContext;
        public UserRepository(MyDatabaseContext myDatabaseContext)
        {
            _dbContext = myDatabaseContext;
        }

        public async Task<User> getUsers(string userName, string password)
        {
            var users= await(from user in _dbContext.Users
                             where user.Name == userName && user.Password == password
                             select user).ToListAsync();
            return users.FirstOrDefault();
           }



            public async Task<User> insertUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }


        public async Task updateUser(int id, User user)
        {

           _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

        }

       

        
    }
}