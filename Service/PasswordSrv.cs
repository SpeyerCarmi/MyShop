using Repository;
using Zxcvbn;



namespace Service
{
    public class PasswordSrv : IPasswordSrv
    {


        public Result checkPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result;
        }
    }
}
