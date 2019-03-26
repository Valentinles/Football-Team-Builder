using System.Collections.Generic;
using System.Linq;
using FTB.Data;
using FTB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FTB.Web.Pages.Teams
{
    public class DetailsModel : PageModel
    {
        public DetailsModel(FtbContext context)
        {
            this.Context = context;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public string League { get; set; }

        public string TeamLogo { get; set; }

        public FtbContext Context { get; set; }

        public IEnumerable<Player> Players { get; set; }

        public IActionResult OnGet(int id)
        { 
            var team = this.Context.Teams.FirstOrDefault(t =>t.Id==id);

            if (team == null)
            {
                return NotFound();
            }
            this.Name = team.Name;
            this.Nationality = team.Nationality;
            this.League = team.League;
            this.TeamLogo = team.TeamLogo;
            this.Players = this.Context.Players.Where(p => p.TeamId == team.Id);

            return this.Page();
        }
    }
}