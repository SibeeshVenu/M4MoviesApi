using M4Movie.Api.Contracts;
using M4Movie.Api.Data;
using M4Movie.Api.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Tests.Service.Data
{
    public class MovieRepositoryTests
    {
        public readonly MovieApiContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public MovieRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MovieApiContext>()
                .UseInMemoryDatabase(databaseName: "M4Movie")
                .Options;

            _context = new MovieApiContext(options);
            _unitOfWork = new UnitOfWork(_context);
            AddMovie();
        }

        private void AddMovie()
        {
            _unitOfWork.Movies.Add(
                            new Movie()
                            {
                                MovieId = 12345, 
                                MovieDescription = "Foul-mouthed mutant mercenary Wade Wilson (AKA. Deadpool).",
                                MovieImage = "https://ia.media-imdb.com/images/M/MV5BMjI3Njg3MzAxNF5BMl5BanBnXkFtZTgwNjI2OTY0NTM@._V1_UX182_CR0,0,182,268_AL_.jpg",
                                MovieName = "Deadpool 2",
                                AverageVote = 8.5,
                                Comments = "Good one",
                                ReleaseDate = DateTime.Now,
                                VoteCount = 200
                            });
            _unitOfWork.Complete();
        }

        [Fact]
        public void Should_Return_Movies()
        {
            var movies = _unitOfWork.Movies.GetAll();
            Assert.NotEmpty(movies);
        }

        //[Fact]
        //public void Shoud_Add_Movie()
        //{
        //    var movie = new Movie
        //    {
        //        MovieDescription = "Test",
        //        MovieImage = "Test",
        //        MovieName = "Test",
        //        AverageVote = 8.5,
        //        Comments = "Good one",
        //        ReleaseDate = DateTime.Now,
        //        VoteCount = 200
        //    };

        //    _unitOfWork.Movies.Add(movie);
        //    _unitOfWork.Complete();

        //    var movies = _unitOfWork.Movies.GetAll();
        //    Assert.Contains<Movie>(movie, movies);
        //}
    }
}
