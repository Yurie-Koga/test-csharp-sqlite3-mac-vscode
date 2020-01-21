using System;
using System.Linq;

namespace test_csharp_sqlite3_mac_vscode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Entity Framework Core!");

            using (var context = new VideoGamesDatabaseContext())
            {
                // Clear and reset database
                context.Database.EnsureDeleted();

                // Create database if it does not exist
                context.Database.EnsureCreated();

                // Add records: Id is autoincremented by default
                // Pattern 1
                context.VideoGames.Add(new VideoGame
                {
                    Title = "Game 1",
                    Platform = "PS4"
                });
                // Pattern 2
                var SG = new VideoGame();
                SG.Title = "Steins's Gate";
                SG.Platform = "PS Vista";
                context.VideoGames.Add(SG);

                // Commit changes
                context.SaveChanges();

                // Fetch all video games
                Console.WriteLine("Current database content:");
                foreach (var videoGame in context.VideoGames.ToList())
                {
                    Console.WriteLine($"- {videoGame.Title} - {videoGame.Platform}");
                }

                // Fetch all PS4 games
                var ps4Games = from v in context.VideoGames where v.Platform == "PS4" select v;
                Console.WriteLine("PS4 Games:");
                foreach (var videoGame in ps4Games)
                {
                    Console.WriteLine($"- {videoGame.Title} - {videoGame.Platform}");
                }

                // Delete PS4 games
                Console.WriteLine("Deleting PS4 Games:");
                context.VideoGames.RemoveRange(ps4Games);

                // Commit changes
                context.SaveChanges();

                // Fetch all video games: PS4 games should be deleted
                Console.WriteLine("Current database content:");
                foreach (var videoGame in context.VideoGames.ToList())
                {
                    Console.WriteLine($"- {videoGame.Title} - {videoGame.Platform}");
                }
            }
        }
    }
}
