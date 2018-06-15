using M4Movie.Api.Contracts;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace M4Movie.Api.Business.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies(string searchType);
        Movie GetMovie(long id);
        void AddMovie(Movie movie);
        IEnumerable<Movie> GetMovies();
        void RemoveFromWatchList(Movie movie);
        Movie GetWatchListMovie(long id);
        Movie UpdateCommentToMovie(Movie movie);
    }
}
