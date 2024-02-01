using EntertainmentWebApi.Model;
using static EntertainmentWebApi.Interfaces.IMovie;

namespace EntertainmentWebApi.Interfaces
{
    /// <summary>
    /// Interface for all the movie details endpoints
    /// </summary>
    public interface IMovie:IDisposable
    {
        public List<Movie> GetMovieListByActorId(int actorId);
        public List<Movie> GetMovieListByGenreId(int genreId);

        public List<Movie> GetMovieDetails();

    }
}
