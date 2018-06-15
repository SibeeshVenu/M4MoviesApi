using M4Movie.Api.Business;
using M4Movie.Api.Business.Interfaces;
using RestSharp;
using Xunit;
using Moq;
using M4Movie_Api.Controllers;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using M4Movie.Api.Contracts;

namespace Tests.Service.Api
{
    public class MovieControllerTests
    {
        private Mock<IMovieService> _mock;
        private readonly MovieController _movieController;

        public MovieControllerTests()
        {
            _mock = new Mock<IMovieService>();
            _movieController = new MovieController(_mock.Object);
        }

        [Fact]
        public void Should_Return_Movies()
        {
            _mock.Setup(item => item.GetMovies("popular")).Returns(It.IsAny<IEnumerable<Movie>>());
            var actual = _movieController.Get("popular");

            _mock.Verify(item => item.GetMovies("popular"), Times.Once);
            Assert.IsAssignableFrom<IActionResult>(actual);
            Assert.NotNull(actual);
        }

        [Fact]
        public void Should_Return_Movie_By_Id()
        {
            _mock.Setup(item => item.GetMovie(1)).Returns(It.IsAny<Movie>());
            var actual = _movieController.Get(1);

            _mock.Verify(item => item.GetMovie(1), Times.Once);
            Assert.IsAssignableFrom<IActionResult>(actual);
            Assert.NotNull(actual);
        }
    }
}
