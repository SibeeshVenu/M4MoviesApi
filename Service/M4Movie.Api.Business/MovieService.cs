using M4Movie.Api.Business.Interfaces;
using M4Movie.Api.Contracts;
using M4Movie.Api.Data.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace M4Movie.Api.Business
{
    public class MovieService : IMovieService
    {
        public MovieService(IUnitOfWork unit) => _unitOfWork = unit;

        private IUnitOfWork _unitOfWork { get; }

        public IEnumerable<Movie> GetMovies(string searchType) => MapMovies(_unitOfWork.Movies.GetMoviesFromTmdb(searchType));

        public IEnumerable<Movie> SearchMovies(string searchText) => MapMovies(_unitOfWork.Movies.SearchMovies(searchText));

        public IEnumerable<Movie> GetWatchListedMoviesByUserId(long userId) => _unitOfWork.Movies.Find(m => m.UserId == userId);

        private IEnumerable<Movie> MapMovies(string data)
        {
            var lstMovies = new List<Movie>();
            if (string.IsNullOrWhiteSpace(data)) return lstMovies;
            var movieData = JObject.Parse(data)["results"];
            lstMovies = JsonConvert.DeserializeObject<List<Movie>>(movieData.ToString());
            return lstMovies;
        }

        public IEnumerable<Movie> GetMovies() => _unitOfWork.Movies.GetAll();

        public void RemoveFromWatchList(Movie movie)
        {
            _unitOfWork.Movies.Remove(movie);
            _unitOfWork.Complete();
        }

        public Movie GetMovie(long id) => MapMovie(_unitOfWork.Movies.GetMovieFromTmdbById(id));

        private Movie MapMovie(string data)
        {
            var movie = JsonConvert.DeserializeObject<Movie>(data);
            return movie;
        }

        public Movie AlreadyWatchListed(Movie movie) => _unitOfWork.Movies.SingleOrDefault(m => m.MovieId == movie.MovieId && m.UserId == movie.UserId);

        public Movie GetComments(long movieId, long userId) => _unitOfWork.Movies.SingleOrDefault(m => m.MovieId == movieId && m.UserId == userId);

        public void AddMovie(Movie movie)
        {
            movie.IsWatchList = true;
            _unitOfWork.Movies.Add(movie);
            _unitOfWork.Complete();
        }

        public Movie UpdateCommentToMovie(Movie movie)
        {
            var watchList = AlreadyWatchListed(movie);
            watchList.Comments = movie.Comments;
            _unitOfWork.Complete();
            return movie;
        }
    }
}
