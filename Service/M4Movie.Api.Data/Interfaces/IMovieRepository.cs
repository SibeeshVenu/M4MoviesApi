using M4Movie.Api.Contracts;
using RestSharp;
using System.Threading.Tasks;

namespace M4Movie.Api.Data.Interfaces
{
    public interface IMovieRepository: IRepository<Movie>
    {
        string GetMoviesFromTmdb(string searchType);
        string SearchMovies(string searchText);
        string GetMovieFromTmdbById(long id);
    }
}
