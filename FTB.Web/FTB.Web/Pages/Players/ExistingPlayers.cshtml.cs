using System.Collections.Generic;
using System.Linq;
using FTB.Data;
using FTB.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FTB.Web.Pages.Players
{
    public class ExistingPlayersModel : PageModel
    {
        public ExistingPlayersModel(FtbContext context)
        {
            this.Context = context;
        }

        public FtbContext Context { get; set; }

        public IEnumerable<PlayerDisplayModel> Players;
            

        public void OnGet()
        {
            Players = (from p in Context.Players
                         join t in Context.Teams
                         on p.TeamId equals t.Id
                         select new PlayerDisplayModel
                         {
                             Id=p.Id,
                             Name = p.PlayerName,
                             PlayerTeamLogo = t.TeamLogo,
                             TeamId=t.Id
                         }).OrderBy(p=>p.Id).ToList();
        }
    }
}