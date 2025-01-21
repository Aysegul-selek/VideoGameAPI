using Microsoft.EntityFrameworkCore;
using VideoGameAPI.Entity;

namespace VideoGameAPI.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext>options):DbContext(options)
    {
        public DbSet<VideoGame> VideoGames { get; set; }
    }
}
