using M4Movie.Api.Contracts;
using M4Movie.Api.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace M4Movie.Api.Data
{
    public class MovieApiContext : DbContext, IMovieApiContext
    {
        public MovieApiContext(DbContextOptions<MovieApiContext> options) :base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        
    }
}
