using M4Movie.Api.Business;
using M4Movie.Api.Business.Interfaces;
using M4Movie.Api.Data.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;
using RestSharp;
using System;
using Newtonsoft.Json;

namespace Tests.Service.Business
{
    public class MovieServiceTests
    {
        private Mock<IUnitOfWork> _mock;
        private IMovieService _movieService;

        public MovieServiceTests()
        {
            _mock = new Moq.Mock<IUnitOfWork>();
            _movieService = new MovieService(_mock.Object);
        }

        [Fact]
        public void GetMovies_Return_Correctly()
        {
            _mock.Setup(item => item.Movies.GetMoviesFromTmdb("popular")).Returns(It.IsAny<string>());
            var actual = _movieService.GetMovies("popular");
            Assert.NotNull(actual);
        }

        [Fact]
        public void GetMovies_UnitOfService_GetAll_Called_Correctly()
        {
            _mock.Setup(item => item.Movies.GetMoviesFromTmdb("popular")).Returns(It.IsAny<string>());
            var actual = _movieService.GetMovies("popular");
            _mock.Verify(item => item.Movies.GetMoviesFromTmdb("popular"), Times.Once);
        }
    }
}
