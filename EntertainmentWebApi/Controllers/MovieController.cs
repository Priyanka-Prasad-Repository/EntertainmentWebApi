using EntertainmentWebApi.Interfaces;
using EntertainmentWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EntertainmentWebApi.Controllers
{
    /// <summary>
    /// MovieController 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovie movies;
        private readonly ILogger<MovieController> logger;

        public MovieController(IMovie movies, ILogger<MovieController> logger)
        {
            this.movies = movies;
            this.logger = logger;
        }

        /// <summary>
        /// GetMovieListByActorId
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>

        [HttpGet("/ByActorId")]
        public IActionResult GetMovieListByActorId(int actorId)
        {
            try
            {
                var movie = movies.GetMovieListByActorId(actorId);
                if(movie.Count.Equals(0))
                {
                    return StatusCode(404,"Actor not found");
                }
                this.logger.LogInformation("Getting movie list by actor Id");
                return Ok(movie) ;
            }
            catch (Exception ex)
            {

                this.logger.LogError(ex.Message);
                return StatusCode(500,"Internal server error");
               
            }
        }
        /// <summary>
        /// GetMovieListByGenre
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>

        [HttpGet("GetMovieListByGenre/{genreId}")]
        public IActionResult GetMovieListByGenre(int genreId)
        {
            try
            {
                this.logger.LogInformation("Getting movie list by genre Id");
                var moviesByGenre= movies.GetMovieListByGenreId(genreId);
                if (moviesByGenre.Count.Equals(0))
                {
                    return StatusCode(404, "Genre not found");
                }
                return Ok(moviesByGenre);
            }
            catch (Exception ex)
            {

                this.logger.LogError(ex.Message);
                return StatusCode(500,"Internal server error");
            }
            
          
        }

        /// <summary>
        /// GetMovieDetails
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult GetMovieDetails()
        {
            try
            {
                var getMovieDetails=movies.GetMovieDetails();
                if (getMovieDetails.Count.Equals(0))
                {
                    return StatusCode(404, "Movie not found");
                }
                this.logger.LogInformation("Getting movie list by genre Id");             
                return Ok(getMovieDetails); 
              
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return StatusCode(500,"Internal server error");

            }
         
        }
    }
}
