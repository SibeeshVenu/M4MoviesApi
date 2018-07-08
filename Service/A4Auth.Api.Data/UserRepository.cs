using A4Auth.Api.Data.Interfaces;
using M4Movie.Api.Contracts;
using Microsoft.EntityFrameworkCore;

namespace A4Auth.Api.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {

        }
    }
}
