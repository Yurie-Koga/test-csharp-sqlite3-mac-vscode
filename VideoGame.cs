using System.ComponentModel.DataAnnotations;

namespace test_csharp_sqlite3_mac_vscode
{
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }
    }
}