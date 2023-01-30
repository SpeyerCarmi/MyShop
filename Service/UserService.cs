
using Entities;
using Repository;


namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userDB;

        public UserService(IUserRepository userDB)
        {
            _userDB = userDB;
        }

        public async Task<User> getUsers(string userName, string password)
        {
            User userDB =await _userDB.getUsers(userName, password);
            if (userDB == null)
                return null;
            return userDB;
        }
        

        public async Task <User> insertUser(User user)
        {
            User userDB = await _userDB.insertUser(user);
            if (userDB == null)
                return null;
            return userDB;
        }

        public void updateUser(int id, User user)
        {
            _userDB.updateUser(id, user);

        }
        
       
        
        }
    }



        
