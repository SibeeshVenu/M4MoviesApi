using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace A4Auth.Api.Data
{
    class AuthContextFactory : IDesignTimeDbContextFactory<AuthApiContext>
    {
        public AuthApiContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder<AuthApiContext>();
            var connectionString = configuration.GetConnectionString("A4AuthConnection");
            builder.UseSqlServer(connectionString);
            return new AuthApiContext(builder.Options);
        }
    }
}
