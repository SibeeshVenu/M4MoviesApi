using M4Movie.Api.Contracts;
using Microsoft.EntityFrameworkCore;

namespace A4Auth.Api.Data.Interfaces
{
    public interface IAuthApiContext
    {
        DbSet<User> Users { get; set; }
    }
}
