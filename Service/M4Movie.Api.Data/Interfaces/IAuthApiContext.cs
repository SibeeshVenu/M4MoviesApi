using M4Movie.Api.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace M4Movie.Api.Data.Interfaces
{
    public interface IAuthApiContext
    {
        DbSet<User> Users { get; set; }
    }
}
