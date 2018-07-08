using A4Auth.Api.Data.Interfaces;

namespace A4Auth.Api.Data
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
