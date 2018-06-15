using M4Movie.Api.Constants;
using M4Movie.Api.Contracts;
using M4Movie.Api.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace M4Movie.Api.Data
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(DbContext context) : base(context)
        {

        }

        public string GetMoviesFromTmdb(string searchType)
        {
            //https://api.themoviedb.org/3/movie/popular?api_key=<<api_key>>&language=en-US&page=1
            //https://api.themoviedb.org/3/movie/top_rated?api_key=<<api_key>>&language=en-US&page=1
            //https://api.themoviedb.org/3/movie/upcoming?api_key=<<api_key>>&language=en-US&page=1
            //https://api.themoviedb.org/3/movie/now_playing?api_key=<<api_key>>&language=en-US&page=1
            //https://api.themoviedb.org/3/movie/latest?api_key=<<api_key>>&language=en-US
            var apiUrl = $"{ApiConstants.baseUrl}{ApiConstants.getMovies.Replace("{searchType}", searchType)}{ApiConstants.apiKey}";
            var client = new RestClient(apiUrl);
            var request = new RestRequest(Method.GET);
            return client.ExecuteAsync(request).Result;
        }

        public string GetMovieFromTmdbById(long id)
        {
            var apiUrl = $"{ApiConstants.baseUrl}{ApiConstants.movieById.Replace("{movieId}", id.ToString())}{ApiConstants.apiKey}";
            var client = new RestClient(apiUrl);
            var request = new RestRequest(Method.GET);
            return client.ExecuteAsync(request).Result;
        }
    }
}
