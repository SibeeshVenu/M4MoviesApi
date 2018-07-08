using System;
using System.Threading.Tasks;
using M4Movie.Api.Business.Interfaces;
using M4Movie.Api.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using M4Movie.Api.Constants;
using Microsoft.AspNetCore.Authorization;

namespace M4Movie_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Movies")]    
    public class MovieController : ControllerBase
    {
        public MovieController(IMovieService movieService)
        {
            MovieService = movieService;
        }

        public IMovieService MovieService { get; }

        [HttpGet]
        [Route("{searchType}")]
        public IActionResult Get(string searchType = "popular")
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var movies = MovieService.GetMovies(searchType);
                return Ok(movies);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var movies = MovieService.GetMovies();
                return Ok(movies);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet("{id:long}")]
        public IActionResult Get(long id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var movie = MovieService.GetMovie(id);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        [HttpDelete, Authorize]
        public IActionResult Delete([FromBody] Movie movie)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                MovieService.RemoveFromWatchList(movie);
                return Ok(movie);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPost("addToWatchList"), Authorize]
        public IActionResult Add([FromBody] Movie movie)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var existingMovie = MovieService.GetWatchListMovie(movie.MovieId);
                if (existingMovie != null)
                    return BadRequest(ApiConstants.movieAlreadyExists);
                MovieService.AddMovie(movie);
                return Created("api/Movie/Add", movie);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost, Authorize]
        [Route("addComment")]
        public IActionResult AddComment([FromBody] Movie movie)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var existingMovie = MovieService.GetWatchListMovie(movie.MovieId);
                if (existingMovie == null)
                    return NotFound();
                MovieService.UpdateCommentToMovie(movie);
                return Ok(movie);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}