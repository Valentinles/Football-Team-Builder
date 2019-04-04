using System.Linq;
using FTB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FTB.Web.Pages.Players
{
    public class DetailsModel : PageModel
    {
        public InformationModel(FtbContext context)
        {
            this.Context = context;
        }

        public int Id { get; set; }

        public string PlayerName { get; set; }

        public int Age { get; set; }

        public string Biography { get; set; }

        public string PlayerImage { get; set; }

        public FtbContext Context { get; set; }

        public IActionResult OnGet(int id)
        {
            var player = this.Context.Players.FirstOrDefault(p => p.Id == id);

            if(player==null)
            {
                return NotFound();
            }
            this.PlayerName = player.PlayerName;
            this.Age = player.Age;
            this.PlayerImage = player.PlayerImage;
            this.Biography = player.Biography;

            return this.Page();
        }
    }
}
