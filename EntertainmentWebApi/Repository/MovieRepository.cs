using EntertainmentWebApi.Interfaces;
using EntertainmentWebApi.Model;

namespace EntertainmentWebApi.Repository
{
    /// <summary>
    /// Repository pattern created to abstract and encapsulate the data access layer
    /// </summary>
    public class MovieRepository : IMovie,IDisposable
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        /// <summary>
        /// Gets movie list by  actor Id
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>
        public List<Movie> GetMovieListByActorId(int actorId)
        {
            
            return _context.Movies.Where(s => s.actorId == actorId).ToList();
        }
       
        /// <summary>
        /// Gets movie list by genre id
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>

        public List<Movie> GetMovieListByGenreId(int genreId)
        {
            return   _context.Movies.Where(s => s.Genre.GenreId == genreId).ToList();
        }


        /// <summary>
        /// GetMovieDetails
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public List<Movie> GetMovieDetails()
        {
           return _context.Movies.ToList(); 
           
        }
        public  void Dispose()
        {
            _context.Dispose();
        }

    }
}
