using System;

namespace M4Movie.Api.Constants
{
    public static class ApiConstants
    {
        public static readonly string baseUrl = "https://api.themoviedb.org/3/";
        public static readonly string apiKey = "api_key=415e9238d5188172426c3858b367e468";
        public static readonly string getMovies = "movie/{searchType}?language=en-US&page=1&";
        public static readonly string searchMovies = "search/movie?query={searchText}&language=en-US&page=1&";
        public static readonly string movieById = "movie/{movieId}?page=1&language=en-US&";
        public static readonly string movieAlreadyExists = "Movie is already there in watchlist";

        //https://api.themoviedb.org/3/movie/157336?api_key=415e9238d5188172426c3858b367e468&language=en-US
        ///discover/movie?primary_release_date.gte=2018-04-15&primary_release_date.lte=2018-06-22
        //movie/top_rated?page=1&language=en-US&
    }
}
