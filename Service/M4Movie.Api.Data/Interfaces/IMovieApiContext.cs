using M4Movie.Api.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace M4Movie.Api.Data.Interfaces
{
    public interface IMovieApiContext
    {
        DbSet<Movie> Movies { get; set; }
    }
}
