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
        private readonly ILogger<MovieController> _logger;

        public MovieController(IMovie movies, ILogger<MovieController> logger)
        {
            this.movies = movies;
            this._logger = logger;
        }

        /// <summary>
        /// GetMovieListByActorId
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>

        [HttpGet("/ByActorId")]
        public List<Movie> GetMovieListByActorId(int actorId)
        {
            try
            {
                var movie = movies.GetMovieListByActorId(actorId);
                this._logger.LogInformation("Getting movie list by actor Id");
                return movie ;
            }
            catch (Exception ex)
            {

                this._logger.LogError("ex.Message");
                //TODO:We can have a customised logger and return to the user a response code
                return null;
               
            }
        }
        /// <summary>
        /// GetMovieListByGenre
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>

        [HttpGet("GetMovieListByGenre/{genreId}")]
        public List<Movie> GetMovieListByGenre(int genreId)
        {
            try
            {
                this._logger.LogInformation("Getting movie list by genre Id");
                return movies.GetMovieListByGenreId(genreId);
            }
            catch (Exception ex)
            {

                this._logger.LogError(ex.Message);
                return null;
            }
            
          
        }

        /// <summary>
        /// GetMovieDetails
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpGet("")]
        public List<Movie> GetMovieDetails()
        {
            try
            {
               this._logger.LogInformation("Getting movie list by genre Id");
                return movies.GetMovieDetails();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return null;

            }
         
        }
    }
}
