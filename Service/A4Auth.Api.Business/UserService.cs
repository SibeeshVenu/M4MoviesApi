using A4Auth.Api.Business.Interfaces;
using A4Auth.Api.Data.Interfaces;
using M4Movie.Api.Contracts;
using System.Collections.Generic;

namespace A4Auth.Api.Business
{
    public class UserService : IUserService
    {
        public UserService(IAuthUnitOfWork unit) => _unitOfWork = unit;

        private IAuthUnitOfWork _unitOfWork { get; }

        public IEnumerable<User> GetUsers() => _unitOfWork.Users.GetAll();

        public void AddUser(User user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();
        }

        public User GetUserById(long userId)
        {
            return _unitOfWork.Users.Get(userId);
        }

        public User GetUserByEmail(string userEmail)
        {
            return _unitOfWork.Users.SingleOrDefault(user=>user.UserEmail == userEmail);
        }

        public User IsValidCredential(string userEmail, string password)
        {
            return _unitOfWork.Users.SingleOrDefault(user => user.UserEmail == userEmail && user.Password == password);
        }
    }
}
