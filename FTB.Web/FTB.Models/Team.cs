using System.Collections.Generic;

namespace FTB.Models
{
    public class Team
    {
        public Team()
        {
            this.Players = new List<Player>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public string League { get; set; }

        public string TeamLogo { get; set; }

        public ICollection<Player> Players { get; set; }



    }
}
