using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> logger)
        {
            if (!context.Streamers!.Any())
            {
                context.Streamers!.AddRange(GetPreconfigureStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(StreamerDbContext).Name);
            }
        }

        private static IEnumerable<Streamer> GetPreconfigureStreamer()
        {
            return new List<Streamer>
            {
                new Streamer {CreatedBy = "crisape", Nombre= "Maxi HBP", Url ="http://www.hbp.com" },
                new Streamer {CreatedBy = "crisape", Nombre= "Amazon VIP", Url ="http://www.amazonvip.com" }
            };
        }
    }
}
