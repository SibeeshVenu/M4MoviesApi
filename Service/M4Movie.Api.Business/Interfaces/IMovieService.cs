﻿using M4Movie.Api.Contracts;
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
        Movie AlreadyWatchListed(Movie movie);
        Movie UpdateCommentToMovie(Movie movie);
        IEnumerable<Movie> GetWatchListedMoviesByUserId(long userId);
        IEnumerable<Movie> SearchMovies(string searchText);
        Movie GetComments(long movieId, long userId);
    }
}
