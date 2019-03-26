using FTB.Models;
using System;
using System.Collections.Generic;

namespace FTB.Web.Models
{
    public class TeamDisplayModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public string TeamLogo { get; set; }

        public  List<Player>Players { get; set; }


        public static Func<Team, TeamDisplayModel> FromTeam
        {
            get
            {
                return team => new TeamDisplayModel()
                {
                    Name = team.Name,
                    Nationality = team.Nationality,
                    TeamLogo = team.TeamLogo,
                    Id = team.Id,
                };
            }
        }
    }
}
