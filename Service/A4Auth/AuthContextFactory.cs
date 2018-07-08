using A4Auth.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace A4Auth
{
    class AuthContextFactory : IDesignTimeDbContextFactory<AuthApiContext>
    {
        public AuthContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public AuthApiContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AuthApiContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("A4AuthConnection"));

            return new AuthApiContext(optionsBuilder.Options);
        }
    }
}
