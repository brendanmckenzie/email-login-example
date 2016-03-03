using EmailLogin.Models;

namespace EmailLogin
{
    public interface IUserProvider
    {
        User GetUser(string email);
    }
}