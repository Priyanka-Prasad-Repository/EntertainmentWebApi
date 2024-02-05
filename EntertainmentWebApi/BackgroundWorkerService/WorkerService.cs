
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EntertainmentWebApi.BackgroundWorkerService
{
    /// <summary>
    /// Worker service class to publish daily report
    /// report of Actors with count of
    ///movies, count of different genres, movie count by genres.
    /// </summary>
    public class WorkerService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        #region Constructor
        public WorkerService(IServiceScopeFactory serviceScopeFactory)
        {
            this._serviceScopeFactory = serviceScopeFactory;
        }
        #endregion

        #region Background Tasks
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
             await PublishDailyReport();
           
        }
      
        private  Task PublishDailyReport()
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                   
                    int countOfActors = context.Actors.Count();
                    int countOfMovies = context.Movies.Count();
                    int countOfGenre = context.Genres.Count();
                    Console.WriteLine($"Background worker service running at: {DateTimeOffset.Now}" );
                    Console.WriteLine($"Actors count={countOfActors},Movies count={countOfMovies},Genre Count ={countOfGenre} on {DateTimeOffset.Now}");
                    //TODO:using serilog to log it in a text file
                }

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                 return Task.FromException(ex);
            }
           

          
        }

        #endregion
    }
}
