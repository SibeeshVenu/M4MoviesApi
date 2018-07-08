using A4Auth.Api.Data.Interfaces;
using M4Movie.Api.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace A4Auth.Api.Data
{
    public class AuthApiContext : DbContext, IAuthApiContext
    {

        public AuthApiContext(DbContextOptions<AuthApiContext> options) :base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
