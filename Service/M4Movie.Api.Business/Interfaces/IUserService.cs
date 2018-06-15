using M4Movie.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace M4Movie.Api.Business.Interfaces
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
