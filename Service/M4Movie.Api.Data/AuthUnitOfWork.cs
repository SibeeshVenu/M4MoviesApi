using M4Movie.Api.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace M4Movie.Api.Data
{
    public class AuthUnitOfWork : IAuthUnitOfWork
    {
        private AuthApiContext _context { get; }
        public IUserRepository Users { get; set; }

        public AuthUnitOfWork(AuthApiContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
