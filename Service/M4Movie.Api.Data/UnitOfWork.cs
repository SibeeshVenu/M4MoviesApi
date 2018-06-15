using M4Movie.Api.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace M4Movie.Api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private MovieApiContext _context { get; }
        public IMovieRepository Movies { get; set; }

        public UnitOfWork(MovieApiContext context)
        {
            _context = context;
            Movies = new MovieRepository(_context);
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
