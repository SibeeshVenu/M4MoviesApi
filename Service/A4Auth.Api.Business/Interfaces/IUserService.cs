using M4Movie.Api.Contracts;
using System.Collections.Generic;

namespace A4Auth.Api.Business.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        void AddUser(User movie);
        User GetUserById(long userId);
        User GetUserByEmail(string email);
        User IsValidCredential(string userEmail, string password);
    }
}
