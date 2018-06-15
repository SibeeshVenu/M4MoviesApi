using M4Movie.Api.Contracts;
using M4Movie.Api.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace M4Movie.Api.Data
{
    public class AuthApiContext : DbContext, IAuthApiContext
    {
        public AuthApiContext(DbContextOptions<AuthApiContext> options) :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        
    }
}
