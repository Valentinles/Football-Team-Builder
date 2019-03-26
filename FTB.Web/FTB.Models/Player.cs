
namespace FTB.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string PlayerName { get; set; }

        public int Age { get; set; }

        public string Biography { get; set; }

        public string PlayerImage { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }
    }
}
