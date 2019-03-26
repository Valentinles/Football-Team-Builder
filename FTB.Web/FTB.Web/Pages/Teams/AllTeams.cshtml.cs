using System.Collections.Generic;
using System.Linq;
using FTB.Data;
using FTB.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FTB.Web.Pages.Teams
{
    public class AllTeamsModel : PageModel
    {
        public AllTeamsModel(FtbContext context)
        {
            this.Context = context;
        }

        public FtbContext Context { get; set; }

        public IEnumerable<TeamDisplayModel> Teams;

        public void OnGet()
        {
            this.Teams = this.Context.Teams
                .OrderBy(t => t.Name)
                .Select(TeamDisplayModel.FromTeam)
                .ToList();
        }
    }
}