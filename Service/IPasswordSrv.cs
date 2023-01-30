using Zxcvbn;

namespace Service
{
    public interface IPasswordSrv
    {
        Result checkPassword(string password);
    }
}