using Microsoft.EntityFrameworkCore;

namespace test_csharp_sqlite3_mac_vscode
{
    /// <summary>
    /// This class handles the sqlite database
    /// </summary>
    public class VideoGamesDatabaseContext : DbContext
    {
        /// <summary>
        /// This property allows to manipulate the video games table
        /// </summary>
        public DbSet<VideoGame> VideoGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Specify the path of the database here
            optionsBuilder.UseSqlite("Filename=./video-gabes.sqlite");
        }
    }
}